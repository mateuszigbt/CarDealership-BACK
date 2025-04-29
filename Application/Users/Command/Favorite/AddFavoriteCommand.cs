using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.Favorite
{
    public class AddFavoriteCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int VehicleId { get; set; }
    }
}
