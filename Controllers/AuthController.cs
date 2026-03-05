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
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await _authService.Login(loginRequest.Email, loginRequest.Password);

                return Ok(new { token = response });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new Error
                {
                    Code = "4040",
                    Message = ex.Message
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new Error
                {
                    Code = "4010",
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new Error
                {
                    Code = "5000",
                    Message = "Internal server error"
                });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerDto)
        {
            try
            {
                var response = await _authService.Register(registerDto);

                return Ok(new
                {
                    Message = "User registered successfully.",
                    UserId = response
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new Error
                {
                    Code = "4002",
                    Message = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new Error
                {
                    Code = "4003",
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new Error
                {
                    Code = "5000",
                    Message = "Internal server error"
                });
            }
        }
    }
}
