using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using WorkForceManagementService.Entities;
using WorkForceManagementService.ModelDTOs;
using WorkForceManagementService.Repositories.Interfaces;

namespace WorkForceManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var response = await _authService.Login(loginRequest.Email, loginRequest.Password);
            if(!string.IsNullOrEmpty(response))
            {
                return Ok(new { token = response });
            }
            return StatusCode((int)HttpStatusCode.Unauthorized, new Error { Code = "4010" , Message = $"Login failed, invalid email or password." });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var response = await _authService.Register(registerDto);
            if (response > 0)
            {
                return Ok(new { Message = "User registered successfully.", UserId = response });
            }
            return StatusCode((int)HttpStatusCode.BadRequest, new Error { Code = "4001", Message = $"Registration failed." });
        }
    }
}
