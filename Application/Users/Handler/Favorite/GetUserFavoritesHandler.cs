using Application.Users.DTOs.Vehicle;
using Application.Users.Queries;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Favorite
{
    public class GetUserFavoritesHandler : IRequestHandler<GetUserFavoritesQuery, List<GetAllVehicleDto>>
    {
        private readonly IFavoriteRepository _repository;

        public GetUserFavoritesHandler(IFavoriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllVehicleDto>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _repository.GetUserFavoritesAsync(request.UserId);

            return vehicles.Select(v => new GetAllVehicleDto
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
            }).ToList();
        }
    }
}
