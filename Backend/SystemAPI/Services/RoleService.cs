using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;
using System.Net.Http;
using SystemAPI.Data;
using SystemAPI.DTOs;
using SystemAPI.Repositories.Interfaces;
using SystemAPI.Services.Interfaces;

namespace SystemAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly SystemDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserRoleRepository _userRoleRepository;

        public RoleService(
            SystemDbContext context,
            IHttpClientFactory httpClientFactory,
            IUserRoleRepository userRoleRepository)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<bool> AssignDefaultRoleAsync(int userId)
        {
            var client = _httpClientFactory.CreateClient("AuthAPI");
            var response = await client.GetAsync($"/api/auth/users/{userId}");
            if (!response.IsSuccessStatusCode) return false;

            var hasRole = await _context.UserRoleJoins.AnyAsync(r => r.UserID == userId);
            if (hasRole) return false;

            var role = await _userRoleRepository.GetRoleByNameAsync("Kullanici");
if (role == null) {
    Console.WriteLine("Kullanici rolü bulunamadı!");
    return false;
}
else {
    Console.WriteLine($"Kullanici rolü bulundu: {role.Id}");
}


            _context.UserRoleJoins.Add(new UserRoleJoin { UserID = userId, RoleID = role.Id });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignRoleAsync(AssignRoleByIdsDTO dto)
        {
            var client = _httpClientFactory.CreateClient("AuthAPI");
            var response = await client.GetAsync($"/api/auth/users/{dto.RequesterUserId}");
            if (!response.IsSuccessStatusCode) return false;

            var requesterRoles = await _context.UserRoleJoins
                .Where(r => r.UserID == dto.RequesterUserId)
                .Select(r => r.RoleID)
                .ToListAsync();

            var adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole == null || !requesterRoles.Contains(adminRole.Id)) return false;

            var alreadyAssigned = await _context.UserRoleJoins
                .AnyAsync(r => r.UserID == dto.TargetUserId && r.RoleID == dto.RoleId);
            if (alreadyAssigned) return false;

            _context.UserRoleJoins.Add(new UserRoleJoin { UserID = dto.TargetUserId, RoleID = dto.RoleId });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetUserRolesAsync(int userId)
        {
            return await _userRoleRepository.GetUserRolesByUserIdAsync(userId);
        }
    }
}
