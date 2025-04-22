using Application.Users.Command;
using Application.Users.Command.Vehicle;
using Application.Users.DTOs.Vehicle;
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

        [HttpGet("getVehicleById={vehicleId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdVehicle(int vehicleId)
        {
            var vehicle = await _mediator.Send(new GetVehicleByIdCommand { VehicleId = vehicleId });

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPut("update{vehicleId}")]
        public async Task<IActionResult> UpdateVehicle(int vehicleId, [FromBody] UpdateVehicleDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var command = new UpdateVehicleCommand
            {
                VehicleId = vehicleId,
                UserId = userId,
                UpdateVehicle = dto
            };

            var result = await _mediator.Send(command);
            return result ? NoContent() : Unauthorized();
        }

        [HttpDelete("delete={vehicleId}")]
        public async Task<IActionResult> DeleteVehicle(int vehicleId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _mediator.Send(new DeleteVehicleCommand
            {
                VehicleId = vehicleId,
                UserId= userId
            });

            return result ? NoContent() : Unauthorized();
        }
    }
}
