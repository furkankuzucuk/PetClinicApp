using PetClinicApp.Shared.Data.Models;
using VaccinationAPI.DTOs;

using VaccinationAPI.Repositories.Interfaces;
using VaccinationAPI.Services.Interfaces;

namespace VaccinationAPI.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IVaccinationRepository _repository;

        public VaccinationService(IVaccinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vaccination> CreateVaccinationAsync(CreateVaccinationDTO dto)
        {
            int repeatDays = 0;
            DateTime? nextDate = null;

            // 🔁 Eğer aşının tekrar edilmesi gerekiyorsa
            if (dto.RequiresRepeat)
            {
                if (dto.RepeatAfterDays.HasValue && dto.RepeatAfterDays.Value > 0)
                {
                    // Kullanıcı özel tekrar günü girdiyse onu kullan
                    repeatDays = dto.RepeatAfterDays.Value;
                }
                else
                {
                    // Aksi halde VaccineTypes tablosundan varsayılan tekrar süresini al
                    repeatDays = await _repository.GetDefaultRepeatDaysByTypeId(dto.VaccineTypeId);
                }

                // ➕ ApplicationDate üzerine tekrar süresi kadar gün ekle
                nextDate = dto.ApplicationDate.AddDays(repeatDays);
            }

            // 💉 Aşı kaydını oluştur
            var vaccination = new Vaccination
            {
                PetId = dto.PetId,
                VetUserId = dto.VetUserId,
                VaccineTypeId = dto.VaccineTypeId,
                ApplicationDate = dto.ApplicationDate,
                RequiresRepeat = dto.RequiresRepeat,
                RepeatAfterDays = dto.RepeatAfterDays,
                NextDate = nextDate
            };

            return await _repository.AddVaccinationAsync(vaccination);
        }

        public async Task<IEnumerable<VaccinationDTO>> GetVaccinationsByPetIdAsync(int petId)
        {
            var vaccinations = await _repository.GetVaccinationsByPetIdAsync(petId);

            return vaccinations.Select(v => new VaccinationDTO
            {
                Id = v.Id,
                PetId = v.PetId,
                VetUserId = v.VetUserId,
                VaccineTypeId = v.VaccineTypeId,
                ApplicationDate = v.ApplicationDate,
                RequiresRepeat = v.RequiresRepeat,
                RepeatAfterDays = v.RepeatAfterDays,
                NextDate = v.NextDate
            });
        }
public async Task<List<VaccinationDTO>> GetUpcomingVaccinationsAsync(int daysBefore = 3)
{
    var list = await _repository.GetVaccinationsDueSoonAsync(daysBefore);

    return list.Select(v => new VaccinationDTO
    {
        Id = v.Id,
        PetId = v.PetId,
        VetUserId = v.VetUserId,
        VaccineTypeId = v.VaccineTypeId,
        ApplicationDate = v.ApplicationDate,
        RequiresRepeat = v.RequiresRepeat,
        RepeatAfterDays = v.RepeatAfterDays,
        NextDate = v.NextDate
    }).ToList();
}


    }
}
