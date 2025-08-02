using PetClinicApp.Shared.Data.Models;

namespace AppointmentAPI.Repositories.Interfaces
{
    public interface IVetWorkingHourRepository
    {
        Task<List<VetWorkingHour>> GetWorkingHoursByVetAsync(int vetUserId, DateTime date);
    }
}
