using PetClinicApp.Shared.Data.Models;

namespace AppointmentAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        Task<bool> IsVetAvailableAsync(int vetUserId, DateTime appointmentTime);
        Task<Appointment?> GetAppointmentByIdAsync(int appointmentId);
        Task SaveChangesAsync();
Task<IEnumerable<Appointment>> GetAppointmentsByVetIdAsync(int vetUserId);


    }
}
