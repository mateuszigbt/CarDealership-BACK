using Application.Users.Command.Favorite;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{vehicleId}")]
        public async Task<IActionResult> AddFavorite(int vehicleId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _mediator.Send(new AddFavoriteCommand { UserId = userId, VehicleId = vehicleId });
            return NoContent();
        }

        [HttpDelete("{vehicleId}")]
        public async Task<IActionResult> RemoveFavorite(int vehicleId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _mediator.Send(new RemoveFavoriteCommand { UserId = userId, VehicleId = vehicleId });
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _mediator.Send(new GetUserFavoritesQuery { UserId = userId });
            return Ok(result);
        }
    }
}
