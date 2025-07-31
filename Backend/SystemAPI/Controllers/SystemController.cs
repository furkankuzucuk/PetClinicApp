using Microsoft.AspNetCore.Mvc;
using SystemAPI.DTOs;
using SystemAPI.Services.Interfaces;

namespace SystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public SystemController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("assign-default-role")]
        public async Task<IActionResult> AssignDefaultRole([FromBody] int userId)
        {
            var success = await _roleService.AssignDefaultRoleAsync(userId);
            if (!success)
                return BadRequest(new { error = "Varsayılan rol atanamadı." });

            return Ok(new { message = "Varsayılan rol atandı." });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleByIdsDTO dto)
        {
            var success = await _roleService.AssignRoleAsync(dto);
            if (!success)
                return StatusCode(403, new { error = "Yetkisiz işlem veya geçersiz veri." });

            return Ok(new { message = "Rol başarıyla atandı." });
        }

        [HttpGet("get-user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var roles = await _roleService.GetUserRolesAsync(userId);
            var roleNames = roles.Select(r => r.Name).ToList();
            return Ok(roleNames);
        }
    }
}
