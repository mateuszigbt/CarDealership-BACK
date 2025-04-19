using Application.Users.Command;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public AddVehicleCommandHandler(IVehicleRepository vehicleRepository) 
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                TypeOffer = request.Vehicle.TypeOffer,
                IsDamaged = request.Vehicle.IsDamaged,
                IsImported = request.Vehicle.IsImported,
                Vin = request.Vehicle.Vin,
                Distance = request.Vehicle.Distance,
                RegistrationNumber = request.Vehicle.RegistrationNumber,
                FirstRegistration = request.Vehicle.FirstRegistration,
                YearProduction = request.Vehicle.YearProduction,
                BrandVehicle = request.Vehicle.BrandVehicle,
                ModelVehicle = request.Vehicle.ModelVehicle,
                TypeOfFuel = request.Vehicle.TypeOfFuel,
                HorsePower = request.Vehicle.HorsePower,
                Displacement = request.Vehicle.Displacement,
                Doors = request.Vehicle.Doors,
                Transmission = request.Vehicle.Transmission,
                Version = request.Vehicle.Version,
                Generation = request.Vehicle.Generation,
                BodyType = request.Vehicle.BodyType,
                SourceImages = request.Vehicle.SourceImages,
                TitleOffer = request.Vehicle.TitleOffer,
                Description = request.Vehicle.Description,
                Price = request.Vehicle.Price,
                UserId = request.UserId
            };

            await _vehicleRepository.AddVehicleAsync(vehicle);
            return vehicle.Id;
        }
    }
}
