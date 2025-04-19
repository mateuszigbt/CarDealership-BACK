using Application.Users.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(command);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new {Token = token});
        }
    }
}
