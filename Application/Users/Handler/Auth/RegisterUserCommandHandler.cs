using Application.Users.Command.ResetPassword;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Auth
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.User.Password);

            var user = new User
            {
                Name = request.User.Name,
                Surename = request.User.Surename,
                Email = request.User.Email,
                Password = hashedPassword,
                Role = UserRole.User
            };

            await _userRepository.AddUserAsync(user);
            return user.Id;
        }
    }
}
