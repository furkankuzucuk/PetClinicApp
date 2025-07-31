using AuthAPI.DTOs;
using System.Threading.Tasks;
using PetClinicApp.Shared.Data.Models;


namespace AuthAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDTO dto); // token string
        Task<int> RegisterAsync(RegisterDTO dto); // user ID
            Task<User?> GetUserByIdAsync(int id);
    }
}
