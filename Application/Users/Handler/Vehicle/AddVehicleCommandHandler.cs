using Application.Users.Command.Vehicle;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Handler.Vehicle
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IHostEnvironment _environment;

        public AddVehicleCommandHandler(IVehicleRepository vehicleRepository, IHostEnvironment environment)
        {
            _vehicleRepository = vehicleRepository;
            _environment = environment;
        }

        public async Task<int> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            var filePaths = new List<string>();

            if (request.Vehicle.SourceImages != null && request.Vehicle.SourceImages.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.ContentRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var file in request.Vehicle.SourceImages)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    filePaths.Add(Path.Combine("uploads", uniqueFileName).Replace("\\", "/"));
                }
            }

            var vehicle = new Domain.Entities.Vehicle
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
                SourceImages = filePaths.ToArray(),
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
