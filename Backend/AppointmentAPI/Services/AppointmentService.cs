using AppointmentAPI.DTOs;
using AppointmentAPI.Repositories.Interfaces;
using AppointmentAPI.Services.Interfaces;
using PetClinicApp.Shared.Data.Models;

namespace AppointmentAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<AppointmentDTO?> CreateAppointmentAsync(CreateAppointmentDTO dto)
        {
            var available = await _repository.IsVetAvailableAsync(dto.VetUserId, dto.AppointmentDateTime);
            if (!available)
                return null;

            var appointment = new Appointment
            {
                UserId = dto.UserId,
                PetId = dto.PetId,
                VetUserId = dto.VetUserId,
                AppointmentDateTime = dto.AppointmentDateTime
            };

            var created = await _repository.CreateAppointmentAsync(appointment);

            return new AppointmentDTO
            {
                Id = created.Id,
                UserId = created.UserId,
                PetId = created.PetId,
                VetUserId = created.VetUserId,
                AppointmentDateTime = created.AppointmentDateTime
            };
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByVetAsync(int vetUserId)
        {
            var appointments = await _repository.GetAppointmentsByVetIdAsync(vetUserId);

            return appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                UserId = a.UserId,
                PetId = a.PetId,
                VetUserId = a.VetUserId,
                AppointmentDateTime = a.AppointmentDateTime
            });
        }
    }
}
