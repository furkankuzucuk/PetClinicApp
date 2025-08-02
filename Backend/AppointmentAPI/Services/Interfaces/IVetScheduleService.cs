using System;
using System.Collections.Generic;

namespace AppointmentAPI.Services.Interfaces
{
    public interface IVetScheduleService
    {
        Task<List<DateTime>> GetAvailableSlotsAsync(int vetUserId, DateTime date);
    }
}
