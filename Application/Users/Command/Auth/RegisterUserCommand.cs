using Application.Users.DTOs.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.ResetPassword
{
    public class RegisterUserCommand : IRequest<int>
    {
        public RegisterUserDto User { get; set; } = new();
    }
}
