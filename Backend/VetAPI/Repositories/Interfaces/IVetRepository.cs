using PetClinicApp.Shared.Data.Models;

namespace VetAPI.Repositories
{
    public interface IVetRepository
    {
        Task<Vet> AddVetAsync(Vet vet);
        Task<Vet?> GetVetByUserIdAsync(int userId);
    }
}
