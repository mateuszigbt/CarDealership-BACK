using Application.Users.Command.ResetPassword;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            string email;

            try
            {
                email = Encoding.UTF8.GetString(Convert.FromBase64String(request.Token));
            }
            catch (Exception)
            {
                return false;
                throw;
            }

            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return false;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _userRepository.UpdateUserAsync(user);

            return true;
        }
    }
}
