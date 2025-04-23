using Application.Users.DTOs.Conversation;
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
    public class GetUserConversationsQueryHandler : IRequestHandler<GetUserConversationsQuery, List<ConversationPreviewDto>>
    {
        private readonly ICorrespondenceRepository _repository;

        public GetUserConversationsQueryHandler(ICorrespondenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ConversationPreviewDto>> Handle(GetUserConversationsQuery request, CancellationToken cancellationToken)
        {
            var conversations = await _repository.GetAllForUserAsync(request.CurrentUserId);

            return conversations
                .Select(c =>
                {
                    var lastMessage = c.Messages.OrderByDescending(m => m.SentAt).FirstOrDefault();

                    var withUser = c.SenderId == request.CurrentUserId ? c.Receiver : c.Sender;

                    return new ConversationPreviewDto
                    {
                        CorrespondenceId = c.Id,
                        WithUserId = withUser.Id,
                        WithUserName = withUser.Email,
                        LastMessage = lastMessage?.Content ?? "",
                        LastMessageDate = lastMessage?.SentAt ?? c.CreatedAt,
                        VehicleTitle = c.Vehicle.TitleOffer,
                        VehicleImage = c.Vehicle.SourceImages.FirstOrDefault()
                    };
                })
                .OrderByDescending(x => x.LastMessageDate)
                .ToList();
        }
    }
}
