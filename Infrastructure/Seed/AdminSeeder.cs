using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class AdminSeeder
    {
        private readonly AppDbContext _context;

        public AdminSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAdminAsync()
        {
            var existingAdmin = await _context.Users.FirstOrDefaultAsync(u => u.Role == UserRole.Admin);

            if (existingAdmin != null)
            {
                return;
            }

            var admin = new User
            {
                Name = "admin",
                Surename = "system",
                Email = "admin@cardealer.com",
                Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                Role = UserRole.Admin
            };

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();
        }
    }
}
