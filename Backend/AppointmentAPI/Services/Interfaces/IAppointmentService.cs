using AppointmentAPI.DTOs;
namespace AppointmentAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO?> CreateAppointmentAsync(CreateAppointmentDTO dto);
        
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByVetAsync(int vetUserId);


    }
}
