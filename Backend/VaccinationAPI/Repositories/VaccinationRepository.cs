using PetClinicApp.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;

using VaccinationAPI.Data;
using VaccinationAPI.Repositories.Interfaces;

namespace VaccinationAPI.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly VaccinationDbContext _context;

        public VaccinationRepository(VaccinationDbContext context)
        {
            _context = context;
        }

        public async Task<Vaccination> AddVaccinationAsync(Vaccination vaccination)
        {
            _context.Vaccinations.Add(vaccination);
            await _context.SaveChangesAsync();
            return vaccination;
        }
        public async Task<int> GetDefaultRepeatDaysByTypeId(int vaccineTypeId)
        {
            var type = await _context.VaccineTypes.FindAsync(vaccineTypeId);
            return type?.DefaultRepeatDays ?? 0;
        }
        public async Task<List<Vaccination>> GetVaccinationsByPetIdAsync(int petId)
        {
            return await _context.Vaccinations
            .Where(v => v.PetId == petId)
            .OrderByDescending(v => v.ApplicationDate)
            .ToListAsync();
        }

        public async Task<List<Vaccination>> GetVaccinationsDueSoonAsync(int daysBefore = 3)
        {
            var now = DateTime.Now;
            var upperLimit = now.AddDays(daysBefore);

            return await _context.Vaccinations
                    .Where(v => v.RequiresRepeat &&
                    v.NextDate != null &&
                    v.NextDate >= now &&
                    v.NextDate <= upperLimit)
                  .ToListAsync();
}




    }
}
