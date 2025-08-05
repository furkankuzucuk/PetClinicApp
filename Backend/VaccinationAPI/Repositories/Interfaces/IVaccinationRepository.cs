using PetClinicApp.Shared.Data.Models;

namespace VaccinationAPI.Repositories.Interfaces
{
    public interface IVaccinationRepository
    {
        Task<Vaccination> AddVaccinationAsync(Vaccination vaccination);
        Task<int> GetDefaultRepeatDaysByTypeId(int vaccineTypeId);
        Task<List<Vaccination>> GetVaccinationsByPetIdAsync(int petId);

        


    }
}
