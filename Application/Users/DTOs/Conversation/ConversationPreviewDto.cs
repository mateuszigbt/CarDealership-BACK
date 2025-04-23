using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs.Conversation
{
    public class ConversationPreviewDto
    {
        public int CorrespondenceId { get; set; }
        public int WithUserId { get; set; }
        public string WithUserName { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }
        public string VehicleTitle { get; set; }
        public string VehicleImage { get; set; }
    }
}
