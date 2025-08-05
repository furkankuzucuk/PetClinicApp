using PetClinicApp.Shared.Data.Models;

namespace VetAPI.Repositories.Interfaces
{
    public interface IExaminationRepository
    {
        Task<Examination> AddExaminationAsync(Examination examination);
        Task<List<Examination>> GetExaminationsByPetIdAsync(int petId);
    }
}
