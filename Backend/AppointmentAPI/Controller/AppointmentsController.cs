using AppointmentAPI.DTOs;
using AppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDTO dto)
        {
            var result = await _service.CreateAppointmentAsync(dto);
            if (result == null)
                return Conflict("Seçilen saatte veterinerin başka bir randevusu var.");

            return Ok(result);
        }

        [HttpGet("vet/{vetUserId}")]
        public async Task<IActionResult> GetByVet(int vetUserId)
        {
            var appointments = await _service.GetAppointmentsByVetAsync(vetUserId);
            return Ok(appointments);
        }
    }
}
