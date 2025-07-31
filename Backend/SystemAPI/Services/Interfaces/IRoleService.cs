using SystemAPI.DTOs;
using PetClinicApp.Shared.Data.Models;

namespace SystemAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AssignDefaultRoleAsync(int userId);
        Task<bool> AssignRoleAsync(AssignRoleByIdsDTO dto);
        Task<List<Role>> GetUserRolesAsync(int userId);
    }
}
