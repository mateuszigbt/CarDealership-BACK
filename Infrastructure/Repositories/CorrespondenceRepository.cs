using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CorrespondenceRepository : ICorrespondenceRepository
    {
        private readonly AppDbContext _context;

        public CorrespondenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Correspondence?> GetCorrespondenceAsync(int senderId, int receiverId, int vehicleId)
        {
            return await _context.Correspondences
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c =>
                    c.VehicleId == vehicleId &&
                    (
                        (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                        (c.SenderId == receiverId && c.ReceiverId == senderId)
                    ));
        }

        public async Task<List<Message>> GetMessagesByCorespondenceAsync(int vehicleId, int user1, int user2)
        {
            return await _context.Messages
                .Where(m =>
                    m.Correspondence.VehicleId == vehicleId &&
                    (
                        (m.SenderId == user1 && m.ReceiverId == user2) ||
                        (m.SenderId == user2 && m.ReceiverId == user1)
                    ))
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<List<Correspondence>> GetAllForUserAsync(int userId)
        {
            return await _context.Correspondences
                .Include(c => c.Messages)
                .Include(c => c.Vehicle)
                .Include(c => c.Sender)
                .Include(c => c.Receiver)
                .Where(c => c.SenderId != userId || c.ReceiverId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Correspondence correspondence)
        {
            await _context.Correspondences.AddAsync(correspondence);
            await _context.SaveChangesAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

    }
}
