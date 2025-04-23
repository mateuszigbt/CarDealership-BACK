using Application.Users.Command.Message;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Handler.Message
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {
        private readonly ICorrespondenceRepository _repository;

        public SendMessageCommandHandler(ICorrespondenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var correspondence = await _repository.GetCorrespondenceAsync(request.SenderId, request.ReceiverId, request.VehicleId);

            if (correspondence == null) 
            {
                correspondence = new Correspondence
                {
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    VehicleId = request.VehicleId
                };
                await _repository.AddAsync(correspondence);
            }

            var message = new Domain.Entities.Message
            {
                Content = request.Content,
                CorrespondenceId = correspondence.Id,
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId
            };

            await _repository.AddMessageAsync(message);
            return true;
        }
    }
}
