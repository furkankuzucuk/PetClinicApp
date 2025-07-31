using PetClinicApp.Shared.Data.Models;

namespace AuthAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(int id);

    }
}
