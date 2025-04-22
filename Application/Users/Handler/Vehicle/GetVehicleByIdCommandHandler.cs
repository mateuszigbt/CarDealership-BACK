using Application.Users.Command.Vehicle;
using Application.Users.DTOs.Vehicle;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Vehicle
{
    public class GetVehicleByIdCommandHandler : IRequestHandler<GetVehicleByIdCommand, GetAllVehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleByIdCommandHandler(IVehicleRepository vehicleRepository) 
        { 
            _vehicleRepository = vehicleRepository;
        }

        public async Task<GetAllVehicleDto> Handle(GetVehicleByIdCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);

            if (vehicle == null)
            {
                return null;
            }

            return new GetAllVehicleDto
            {
                Id = vehicle.Id,
                TypeOffer = vehicle.TypeOffer,
                IsDamaged = vehicle.IsDamaged,
                IsImported = vehicle.IsImported,
                Vin = vehicle.Vin,
                Distance = vehicle.Distance,
                RegistrationNumber = vehicle.RegistrationNumber,
                FirstRegistration = vehicle.FirstRegistration,
                YearProduction = vehicle.YearProduction,
                BrandVehicle = vehicle.BrandVehicle,
                ModelVehicle = vehicle.ModelVehicle,
                TypeOfFuel = vehicle.TypeOfFuel,
                HorsePower = vehicle.HorsePower,
                Displacement = vehicle.Displacement,
                Doors = vehicle.Doors,
                Transmission = vehicle.Transmission,
                Version = vehicle.Version,
                Generation = vehicle.Generation,
                BodyType = vehicle.BodyType,
                SourceImages = vehicle.SourceImages,
                TitleOffer = vehicle.TitleOffer,
                Description = vehicle.Description,
                Price = vehicle.Price,
                UserId = vehicle.UserId
            };

        }
    }
}
