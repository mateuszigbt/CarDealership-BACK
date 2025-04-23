using Application.Users.DTOs.Conversation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserConversationsQuery : IRequest<List<ConversationPreviewDto>>
    {
        public int CurrentUserId { get; set; }
    }
}
