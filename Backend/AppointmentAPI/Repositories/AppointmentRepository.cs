using AppointmentAPI.Data;
using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;
using AppointmentAPI.Repositories.Interfaces;

namespace AppointmentAPI.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDbContext _context;

        public AppointmentRepository(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> IsVetAvailableAsync(int vetUserId, DateTime appointmentTime)
        {
            return !await _context.Appointments
                .AnyAsync(a => a.VetUserId == vetUserId && a.AppointmentDateTime == appointmentTime);
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
{
    return await _context.Appointments.FindAsync(appointmentId);
}

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
public async Task<IEnumerable<Appointment>> GetAppointmentsByVetIdAsync(int vetUserId)
{
    return await _context.Appointments
        .Where(a => a.VetUserId == vetUserId)
        .OrderBy(a => a.AppointmentDateTime)
        .ToListAsync();
}


    }
}
