using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly AppDbContext _context;

        public PasswordResetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveTokenAsync(PasswordResetToken token)
        {
            _context.PasswordResetTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetToken?> GetTokenAsync(string token)
        {
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.Token == token && t.Expiration > DateTime.UtcNow);
        }

        public async Task InvalideTokenAsync(string token)
        {
            var item = await _context.PasswordResetTokens.FirstOrDefaultAsync(t => t.Token == token);

            if (item != null)
            {
                _context.PasswordResetTokens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
