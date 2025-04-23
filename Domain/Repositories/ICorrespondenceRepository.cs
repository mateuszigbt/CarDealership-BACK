using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICorrespondenceRepository
    {
        Task<Correspondence?> GetCorrespondenceAsync(int senderId, int receiverId, int vehicleId);
        Task<List<Message>> GetMessagesByCorespondenceAsync(int vehicleId, int user1, int user2);
        Task<List<Correspondence>> GetAllForUserAsync(int userId);
        Task AddAsync(Correspondence correspondence);
        Task AddMessageAsync(Message message);
    }
}
