using Application.Users.DTOs.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.Vehicle
{
    public class GetVehicleByIdCommand : IRequest<GetAllVehicleDto>
    {
        public int VehicleId { get; set; }
    }
}
