using Application.Users.Command.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordResetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] string email)
        {
            await _mediator.Send(new RequestResetPasswordCommand { Email = email });
            return Ok("Reset link sent.");
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Password changed.") : BadRequest("Invalid token or user.");
        }
    } // zaaktualizwac do bazy i migracja
}
