using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPasswordResetRepository
    {
        Task SaveTokenAsync(PasswordResetToken token);
        Task<PasswordResetToken> GetTokenAsync(string token);
        Task InvalideTokenAsync(string token);
    }
}
