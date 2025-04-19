using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
