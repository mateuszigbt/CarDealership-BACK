using Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command
{
    public class AddVehicleCommand : IRequest<int>
    {
        public AddVehicleDto Vehicle { get; set; } = new();
        public int UserId { get; set; }
    }
}
