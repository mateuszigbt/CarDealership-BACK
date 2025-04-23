using Application.Users.Command.Message;
using Application.Users.DTOs.Message;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var senderId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var command = new SendMessageCommand
            {
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                VehicleId = dto.VehicleId,
                Content = dto.Content
            };

            var success = await _mediator.Send(command);
            return success ? Ok() : BadRequest("Failed to send message.");
        }

        [HttpGet("vehicle/{vehicleId}/with/{receiverId}")]
        public async Task<IActionResult> GetMessages(int vehicleId, int receiverId)
        {
            var senderId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var query = new GetMessagesQuery
            {
                VehicleId = vehicleId,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        [HttpGet("conversations")]
        public async Task<IActionResult> GetUserConversations()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var query = new GetUserConversationsQuery { CurrentUserId = userId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
