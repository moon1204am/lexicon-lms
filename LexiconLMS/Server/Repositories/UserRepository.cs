using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetParticipantsAsync(Guid courseId)
        {
            var users = await _context.ApplicationUser.Where(p => p.CourseId == courseId).Include(u => u.Roles).ToListAsync();
            return users;
        }
    }
}
