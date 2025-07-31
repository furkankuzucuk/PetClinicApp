using PetClinicApp.Shared.Data.Models;

namespace PetAPI.Repositories
{
    public interface IPetRepository
    {
        Task<Pet> AddPetAsync(Pet pet);
        Task<IEnumerable<Pet>> GetPetsByUserIdAsync(int userId);
    }
}
