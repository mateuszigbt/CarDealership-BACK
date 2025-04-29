using Application.Users.DTOs.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserFavoritesQuery : IRequest<List<GetAllVehicleDto>>
    {
        public int UserId { get; set; }
    }
}
