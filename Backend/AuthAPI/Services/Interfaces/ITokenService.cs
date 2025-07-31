using PetClinicApp.Shared.Data.Models;

namespace AuthAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, List<string> roleNames);
    }
}
