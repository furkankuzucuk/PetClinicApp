using AuthAPI.DTOs;
using AuthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // 📝 Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            try
            {
                int userId = await _authService.RegisterAsync(dto);
                return Ok(new { message = "Kayıt başarılı", userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // 🔐 Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);
                if (token == null)
                    return Unauthorized(new { error = "Geçersiz kullanıcı adı veya şifre" });

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // 🔍 SystemAPI için: Kullanıcıyı ID ile getirme
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _authService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"ID {id} için kullanıcı bulunamadı." });

            return Ok(user);
        }
    }
}
