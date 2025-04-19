using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicleAsync();
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
    }
}
