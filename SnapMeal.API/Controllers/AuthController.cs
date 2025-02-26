using Microsoft.AspNetCore.Mvc;
using SnapMeal.API.Services;
using SnapMeal.API.Models;
using System.Threading.Tasks;

namespace SnapMeal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await _authService.RegisterAsync(user);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var result = await _authService.LoginAsync(userLogin);
            if (result.Success)
            {
                return Ok(result.Token);
            }
            return Unauthorized(result.Message);
        }
    }
}
