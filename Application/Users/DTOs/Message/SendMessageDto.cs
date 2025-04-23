using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs.Message
{
    public class SendMessageDto
    {
        public int ReceiverId { get; set; }
        public int VehicleId { get; set; }
        public string Content { get; set; }
    }
}
