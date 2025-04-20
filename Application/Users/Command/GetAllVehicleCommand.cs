using Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command
{
    public class GetAllVehicleCommand : IRequest<List<GetAllVehicleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
