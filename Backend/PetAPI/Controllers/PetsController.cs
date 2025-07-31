using Microsoft.AspNetCore.Mvc;
using PetAPI.DTOs;
using PetAPI.Services;

namespace PetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPet([FromBody] CreatePetDTO dto)
        {
            var result = await _petService.CreatePetAsync(dto);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPets(int userId)
        {
            var result = await _petService.GetUserPetsAsync(userId);
            return Ok(result);
        }
    }
}
