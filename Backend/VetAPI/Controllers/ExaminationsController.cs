using Microsoft.AspNetCore.Mvc;
using VetAPI.DTOs;
using VetAPI.Services.Interfaces;

namespace VetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationService _service;

        public ExaminationsController(IExaminationService service)
        {
            _service = service;
        }

        // ✅ Yeni muayene ekle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExaminationDTO dto)
        {
            var result = await _service.CreateExaminationAsync(dto);
            return Ok(result);
        }

        // ✅ Belirli hayvanın muayene geçmişini getir
        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetByPetId(int petId)
        {
            var result = await _service.GetExaminationsByPetIdAsync(petId);
            return Ok(result);
        }
    }
}
