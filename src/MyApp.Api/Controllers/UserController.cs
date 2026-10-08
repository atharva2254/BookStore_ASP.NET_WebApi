using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Service;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var token = await _userService.LoginAsync(request);
            if(token is null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            var user = await _userService.RegisterAsync(request);

            if(user is null)
            {
                return BadRequest("Password doesn't match");
            }

            return Created();
        }
    }
}
