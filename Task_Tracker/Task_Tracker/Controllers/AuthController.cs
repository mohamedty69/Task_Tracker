using Application.Features.Auth.Commands.CommandClasses;
using Application.Features.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Task_Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediatr;

        public AuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            var result = await _mediatr.Send(new RegisterCommand(registerDto));
            if (result.IsSucssed)
                return Created();
            if (result.StatusCode == 400) return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == 403) return Unauthorized(result.ErrorMessage);
            return NotFound(result.ErrorMessage);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            var result = await _mediatr.Send(new LoginCommand(loginDto));
            if (result.IsSucssed)
                return Ok(result.Value);
            if (result.StatusCode == 400) return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == 403) return Unauthorized(result.ErrorMessage);
            return NotFound(result.ErrorMessage);
        }
    }
}
