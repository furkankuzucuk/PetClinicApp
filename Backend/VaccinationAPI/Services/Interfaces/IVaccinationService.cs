using VaccinationAPI.DTOs;
using PetClinicApp.Shared.Data.Models;

namespace VaccinationAPI.Services.Interfaces
{
    public interface IVaccinationService
    {
        Task<Vaccination> CreateVaccinationAsync(CreateVaccinationDTO dto);
        Task<IEnumerable<VaccinationDTO>> GetVaccinationsByPetIdAsync(int petId);
        Task<List<VaccinationDTO>> GetUpcomingVaccinationsAsync(int daysBefore = 3);


    }
}
