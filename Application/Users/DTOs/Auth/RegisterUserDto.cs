﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs.Auth
{
    public class RegisterUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surename { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
