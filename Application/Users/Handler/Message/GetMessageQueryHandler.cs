using Application.Users.DTOs.Message;
using Application.Users.Queries;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Message
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessagesQuery, List<MessageDto>>
    {
        private readonly ICorrespondenceRepository _repository;

        public GetMessageQueryHandler(ICorrespondenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _repository.GetMessagesByCorespondenceAsync(request.VehicleId, request.SenderId, request.ReceiverId);

            return messages.Select(m => new MessageDto
            {
                SenderId = m.SenderId,
                Content = m.Content,
                SenderName = m.Sender?.Name ?? "User",
                SentAt = m.SentAt
            }).ToList();
        }
    }
}
