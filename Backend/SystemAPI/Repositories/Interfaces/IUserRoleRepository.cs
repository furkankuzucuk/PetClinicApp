using PetClinicApp.Shared.Data.Models;

namespace SystemAPI.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<List<Role>> GetUserRolesByUserIdAsync(int userId);
    }
}
