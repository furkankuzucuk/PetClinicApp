using VetAPI.DTOs;

namespace VetAPI.Services.Interfaces
{
    public interface IExaminationService
    {
        Task<ExaminationDTO> CreateExaminationAsync(CreateExaminationDTO dto);
        Task<IEnumerable<ExaminationDTO>> GetExaminationsByPetIdAsync(int petId);
    }
}
