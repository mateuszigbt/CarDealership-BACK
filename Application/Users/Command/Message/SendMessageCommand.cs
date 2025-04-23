using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.Message
{
    public class SendMessageCommand : IRequest<bool>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int VehicleId { get; set; }
        public string Content { get; set; }
    }
}
