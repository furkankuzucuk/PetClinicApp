using VetAPI.DTOs;
using VetAPI.Repositories.Interfaces;
using VetAPI.Services.Interfaces;
using PetClinicApp.Shared.Data.Models;

namespace VetAPI.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _repository;

        public ExaminationService(IExaminationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExaminationDTO> CreateExaminationAsync(CreateExaminationDTO dto)
        {
            var examination = new Examination
            {
                PetId = dto.PetId,
                VetUserId = dto.VetUserId,
                ExaminationDate = dto.ExaminationDate,
                Diagnosis = dto.Diagnosis,
                Treatment = dto.Treatment,
                Prescription = dto.Prescription
            };

            var created = await _repository.AddExaminationAsync(examination);

            return new ExaminationDTO
            {
                Id = created.Id,
                PetId = created.PetId,
                VetUserId = created.VetUserId,
                ExaminationDate = created.ExaminationDate,
                Diagnosis = created.Diagnosis,
                Treatment = created.Treatment,
                Prescription = created.Prescription
            };
        }

        public async Task<IEnumerable<ExaminationDTO>> GetExaminationsByPetIdAsync(int petId)
        {
            var list = await _repository.GetExaminationsByPetIdAsync(petId);

            return list.Select(e => new ExaminationDTO
            {
                Id = e.Id,
                PetId = e.PetId,
                VetUserId = e.VetUserId,
                ExaminationDate = e.ExaminationDate,
                Diagnosis = e.Diagnosis,
                Treatment = e.Treatment,
                Prescription = e.Prescription
            });
        }
    }
}
