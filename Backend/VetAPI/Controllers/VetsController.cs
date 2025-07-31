using Microsoft.AspNetCore.Mvc;
using VetAPI.DTOs;
using VetAPI.Services;

namespace VetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetsController : ControllerBase
    {
        private readonly IVetService _vetService;

        public VetsController(IVetService vetService)
        {
            _vetService = vetService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVet([FromBody] CreateVetDTO dto)
        {
            var isVet = await _vetService.CheckIfUserIsVet(dto.UserId);
            if (!isVet)
                return Forbid("Bu kullanıcı Veteriner rolüne sahip değil.");

            var result = await _vetService.CreateVetAsync(dto);
            return Ok(result);
        }
    }
}
