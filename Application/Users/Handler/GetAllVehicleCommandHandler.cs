using Application.Users.Command;
using Application.Users.DTOs;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler
{
    public class GetAllVehicleCommandHandler : IRequestHandler<GetAllVehicleCommand, List<GetAllVehicleDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetAllVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<GetAllVehicleDto>> Handle(GetAllVehicleCommand request, CancellationToken cancellationToken)
        {
            var allVehicles = await _vehicleRepository.GetAllVehicleAsync();

            var vehicles = allVehicles
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(v => new GetAllVehicleDto
                {
                    Id = v.Id,
                    TypeOffer = v.TypeOffer,
                    IsDamaged = v.IsDamaged,
                    IsImported = v.IsImported,
                    Vin = v.Vin,
                    Distance = v.Distance,
                    RegistrationNumber = v.RegistrationNumber,
                    FirstRegistration = v.FirstRegistration,
                    YearProduction = v.YearProduction,
                    BrandVehicle = v.BrandVehicle,
                    ModelVehicle = v.ModelVehicle,
                    TypeOfFuel = v.TypeOfFuel,
                    HorsePower = v.HorsePower,
                    Displacement = v.Displacement,
                    Doors = v.Doors,
                    Transmission = v.Transmission,
                    Version = v.Version,
                    Generation = v.Generation,
                    BodyType = v.BodyType,
                    SourceImages = v.SourceImages,
                    TitleOffer = v.TitleOffer,
                    Description = v.Description,
                    Price = v.Price,
                    UserId = v.UserId
                })
                .ToList();
            return vehicles;
        }
    }
}
