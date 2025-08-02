using AppointmentAPI.Repositories.Interfaces;
using AppointmentAPI.Services.Interfaces;
using AppointmentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Services
{
    public class VetScheduleService : IVetScheduleService
    {
        private readonly IVetWorkingHourRepository _workingHourRepo;
        private readonly AppointmentDbContext _context;

        public VetScheduleService(IVetWorkingHourRepository workingHourRepo, AppointmentDbContext context)
        {
            _workingHourRepo = workingHourRepo;
            _context = context;
        }

        public async Task<List<DateTime>> GetAvailableSlotsAsync(int vetUserId, DateTime date)
        {
            var workingHours = await _workingHourRepo.GetWorkingHoursByVetAsync(vetUserId, date);
            var appointments = await _context.Appointments
                .Where(a => a.VetUserId == vetUserId && a.AppointmentDateTime.Date == date.Date)
                .Select(a => a.AppointmentDateTime)
                .ToListAsync();

            var availableSlots = new List<DateTime>();

            foreach (var shift in workingHours)
            {
                for (var slot = shift.StartTime; slot < shift.EndTime; slot = slot.AddMinutes(30))
                {
                    if (!appointments.Contains(slot))
                        availableSlots.Add(slot);
                }
            }

            return availableSlots;
        }
    }
}
