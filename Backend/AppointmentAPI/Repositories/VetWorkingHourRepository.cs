using AppointmentAPI.Data;
using AppointmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace AppointmentAPI.Repositories
{
    public class VetWorkingHourRepository : IVetWorkingHourRepository
    {
        private readonly AppointmentDbContext _context;

        public VetWorkingHourRepository(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<List<VetWorkingHour>> GetWorkingHoursByVetAsync(int vetUserId, DateTime date)
        {
            return await _context.VetWorkingHours
                .Where(w => w.VetUserId == vetUserId &&
                            w.StartTime.Date == date.Date)
                .ToListAsync();
        }
    }
}
