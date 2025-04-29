using Application.Users.Command.Favorite;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Favorite
{
    public class RemoveFavoriteCommandHandler : IRequestHandler<RemoveFavoriteCommand, Unit>
    {
        private readonly IFavoriteRepository _repository;

        public RemoveFavoriteCommandHandler(IFavoriteRepository favoriteRepository)
        {
            _repository = favoriteRepository;
        }

        public async Task<Unit> Handle(RemoveFavoriteCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveFavoriteAsync(request.UserId, request.VehicleId);
            return Unit.Value;
        }
    }
}
