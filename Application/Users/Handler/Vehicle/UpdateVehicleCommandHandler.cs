using Application.Users.Command.Vehicle;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Vehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository) 
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);

            if (vehicle == null || vehicle.UserId != request.UserId)
            {
                return false;
            }

            vehicle.TypeOffer = request.UpdateVehicle.TypeOffer;
            vehicle.IsDamaged = request.UpdateVehicle.IsDamaged;
            vehicle.IsImported = request.UpdateVehicle.IsImported;
            vehicle.Vin = request.UpdateVehicle.Vin;
            vehicle.Distance = request.UpdateVehicle.Distance;
            vehicle.RegistrationNumber = request.UpdateVehicle.RegistrationNumber;
            vehicle.FirstRegistration = request.UpdateVehicle.FirstRegistration;
            vehicle.YearProduction = request.UpdateVehicle.YearProduction;
            vehicle.BrandVehicle = request.UpdateVehicle.BrandVehicle;
            vehicle.ModelVehicle = request.UpdateVehicle.ModelVehicle;
            vehicle.TypeOfFuel = request.UpdateVehicle.TypeOfFuel;
            vehicle.HorsePower = request.UpdateVehicle.HorsePower;
            vehicle.Displacement = request.UpdateVehicle.Displacement;
            vehicle.Doors = request.UpdateVehicle.Doors;
            vehicle.Transmission = request.UpdateVehicle.Transmission;
            vehicle.Version = request.UpdateVehicle.Version;
            vehicle.Generation = request.UpdateVehicle.Generation;
            vehicle.BodyType = request.UpdateVehicle.BodyType;
            vehicle.SourceImages = request.UpdateVehicle.SourceImages;
            vehicle.TitleOffer = request.UpdateVehicle.TitleOffer;
            vehicle.Description = request.UpdateVehicle.Description;
            vehicle.Price = request.UpdateVehicle.Price;

            await _vehicleRepository.UpdateVehicleAsync(vehicle);

            return true;
        }
    }
}
