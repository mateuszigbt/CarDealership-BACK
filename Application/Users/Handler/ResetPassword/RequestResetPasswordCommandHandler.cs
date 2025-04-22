using Application.Users.Command.ResetPassword;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.ResetPassword
{
    public class RequestResetPasswordCommandHandler : IRequestHandler<RequestResetPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public RequestResetPasswordCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(RequestResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return Unit.Value;
            }

            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Email));
            Console.WriteLine(token);

            //var resetLink = $"https://localhost:7171/reset-password?token={token}";

            var smtpClient = new SmtpClient("localhost", 25);
            var mailMessage = new MailMessage("no-reply@example.com", user.Email)
            {
                Subject = "Reset your password",
                /*Body = $@"
                        <p>W celu zresetowania hasła kliknij 
                        <a href='{resetLink}'>tutaj</a>.</p>
                        <p>Albo skopiuj ten link i wklej w przeglądarce:</p>
                        <p><code>{resetLink}</code></p>",
                */
                Body = token,
                IsBodyHtml = true
            };

            await smtpClient.SendMailAsync(mailMessage);

            return Unit.Value;
        }
    }
}
