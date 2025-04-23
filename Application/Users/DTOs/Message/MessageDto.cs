﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs.Message
{
    public class MessageDto
    {
        public int SenderId { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public DateTime SentAt { get; set; }
    }

}
