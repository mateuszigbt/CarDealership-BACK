using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.ResetPassword
{
    public class RequestResetPasswordCommand : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
