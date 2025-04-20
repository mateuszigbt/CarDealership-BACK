using Application.Users.Command;
using Application.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var addVehicleCommand = new AddVehicleCommand
            {
                Vehicle = dto,
                UserId = userId
            };

            var id = await _mediator.Send(addVehicleCommand);
            return Ok(new {id});
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllVehicles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var query = new GetAllVehicleCommand
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var vehicles = await _mediator.Send(query);
            return Ok(vehicles);
        }
    }
}
