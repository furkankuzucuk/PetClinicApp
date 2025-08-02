using AppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetSchedulesController : ControllerBase
    {
        private readonly IVetScheduleService _service;

        public VetSchedulesController(IVetScheduleService service)
        {
            _service = service;
        }

        [HttpGet("{vetUserId}/available-slots")]
        public async Task<IActionResult> GetAvailableSlots(int vetUserId, [FromQuery] DateTime date)
        {
            var slots = await _service.GetAvailableSlotsAsync(vetUserId, date);
            return Ok(slots);
        }
    }
}
