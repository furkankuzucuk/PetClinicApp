using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;
using SystemAPI.Data;
using SystemAPI.Repositories.Interfaces;

namespace SystemAPI.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SystemDbContext _context;

        public UserRoleRepository(SystemDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }

        public async Task<List<Role>> GetUserRolesByUserIdAsync(int userId)
        {
            return await _context.UserRoleJoins
                .Where(ur => ur.UserID == userId)
                .Select(ur => ur.Role)
                .ToListAsync();
        }
    }
}
