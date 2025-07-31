using System.Net.Http.Json;
using VetAPI.DTOs;
using VetAPI.Repositories;
using PetClinicApp.Shared.Data.Models;

namespace VetAPI.Services
{
    public class VetService : IVetService
    {
        private readonly IVetRepository _vetRepository;
        private readonly HttpClient _httpClient;

        public VetService(IVetRepository vetRepository, IHttpClientFactory httpClientFactory)
        {
            _vetRepository = vetRepository;
            _httpClient = httpClientFactory.CreateClient("SystemAPI");
        }

        public async Task<bool> CheckIfUserIsVet(int userId)
        {
            var roles = await _httpClient.GetFromJsonAsync<List<string>>($"api/system/get-user-roles/{userId}");

            return roles != null && roles.Contains("Veteriner");
        }

        public async Task<Vet> CreateVetAsync(CreateVetDTO dto)
        {
            var vet = new Vet
            {
                UserId = dto.UserId,
                DiplomaNumber = dto.DiplomaNumber,
                University = dto.University,
                GraduationYear = dto.GraduationYear,
                Specialization = dto.Specialization
            };

            return await _vetRepository.AddVetAsync(vet);
        }
    }
}
