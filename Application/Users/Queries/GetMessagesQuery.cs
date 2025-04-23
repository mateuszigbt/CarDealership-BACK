using Application.Users.DTOs.Message;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetMessagesQuery : IRequest<List<MessageDto>>
    {
        public int VehicleId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
