using AuthAPI.DTOs;
using AuthAPI.Repositories.Interfaces;
using AuthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using PetClinicApp.Shared.Data.Models;
using System.Net.Http.Json;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            ITokenService tokenService,
            IHttpClientFactory httpClientFactory)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> RegisterAsync(RegisterDTO dto)
        {
            if (await _userRepository.UsernameExistsAsync(dto.KullaniciAdi))
                throw new Exception("Bu kullanıcı adı zaten mevcut");

            var user = new User
            {
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                Email = dto.Email,
                KullaniciAdi = dto.KullaniciAdi,
                DogumTarihi = dto.DogumTarihi,
                Cinsiyet = dto.Cinsiyet,
                Telefon = dto.Telefon,
                Adres = dto.Adres
            };

            user.Sifre = _passwordHasher.HashPassword(user, dto.Sifre);
            var createdUser = await _userRepository.AddAsync(user);

            var client = _httpClientFactory.CreateClient("SystemAPI");

            var roleResponse = await client.PostAsJsonAsync("/api/system/assign-default-role", new
            {
                UserId = createdUser.ID
            });

            if (!roleResponse.IsSuccessStatusCode)
                throw new Exception("Kullanıcı oluşturuldu ama varsayılan rol atanamadı.");

            return createdUser.ID;
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.KullaniciAdi);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Sifre, dto.Sifre);
            if (result != PasswordVerificationResult.Success)
                return null;

            var client = _httpClientFactory.CreateClient("SystemAPI");
            var response = await client.GetAsync($"/api/system/get-user-roles/{user.ID}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Kullanıcı rolleri alınamadı");

            var roleNames = await response.Content.ReadFromJsonAsync<List<string>>();
            return _tokenService.CreateToken(user, roleNames!);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
