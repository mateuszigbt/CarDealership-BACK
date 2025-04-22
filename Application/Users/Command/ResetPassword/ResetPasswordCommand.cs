using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
