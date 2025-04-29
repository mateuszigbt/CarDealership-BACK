using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFavoriteRepository
    {
        Task AddFavoriteAsync(int userId, int vehicleId);
        Task RemoveFavoriteAsync(int userId, int vehicleId);
        Task<bool> IsFavoriteExistsAsync(int userId, int vehicleId);
        Task<List<Vehicle>> GetUserFavoritesAsync(int userId);
    }
}
