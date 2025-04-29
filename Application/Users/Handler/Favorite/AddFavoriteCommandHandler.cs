using Application.Users.Command.Favorite;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Favorite
{
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, Unit>
    {
        public readonly IFavoriteRepository _repository;

        public AddFavoriteCommandHandler(IFavoriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var alredyExists = await _repository.IsFavoriteExistsAsync(request.UserId, request.VehicleId);

            if (alredyExists == false)
            {
                var favorite = new Domain.Entities.Favorite
                {
                    UserId = request.UserId,
                    VehicleId = request.VehicleId,
                };

                await _repository.AddFavoriteAsync(request.UserId, request.VehicleId);
            }

            return Unit.Value;
        }
    }
}
