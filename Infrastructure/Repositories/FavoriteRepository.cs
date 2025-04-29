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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteAsync(int userId, int vehicleId)
        {
            if (!await IsFavoriteExistsAsync(userId, vehicleId))
            {
                var favorite = new Favorite
                {
                    UserId = userId,
                    VehicleId = vehicleId
                };

                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFavoriteAsync(int userId, int vehicleId)
        {
            var fav = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.VehicleId == vehicleId);

            if (fav != null)
            {
                _context.Favorites.Remove(fav);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsFavoriteExistsAsync(int userId, int vehicleId)
        {
            return await _context.Favorites.AnyAsync(f => f.UserId == userId && f.VehicleId == vehicleId);
        }

        public async Task<List<Vehicle>> GetUserFavoritesAsync(int userId)
        {
            return await _context.Favorites
                .Where(f => f.UserId == userId)
                .Select(f => f.Vehicle)
                .ToListAsync();
        }
    }
}
