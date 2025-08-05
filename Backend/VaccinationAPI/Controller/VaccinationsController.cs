using Microsoft.AspNetCore.Mvc;
using VaccinationAPI.DTOs;
using VaccinationAPI.Services.Interfaces;

namespace VaccinationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationService _service;

        public VaccinationsController(IVaccinationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVaccinationDTO dto)
        {
            var result = await _service.CreateVaccinationAsync(dto);
            return Ok(result);
        }

        [HttpGet("pet/{petId}")]
public async Task<IActionResult> GetByPetId(int petId)
{
    var result = await _service.GetVaccinationsByPetIdAsync(petId);
    return Ok(result);
}

    }
}
