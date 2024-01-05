using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
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
            return await _context.ApplicationUser.Where(u => u.CourseId == courseId)
            .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
            .Join(_context.Roles, uur => uur.ur.RoleId, r => r.Id, (uur, r) => new { uur, r })
            .Select(userAndRoleWithIdentityRole => new ApplicationUser
            {
                FirstName = userAndRoleWithIdentityRole.uur.u.FirstName,
                LastName = userAndRoleWithIdentityRole.uur.u.LastName,
                Role = userAndRoleWithIdentityRole.r.Name
            }).ToListAsync();
        }

        //Todo: new call to database to get roles, LMS data service
        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetRoleAsync(Guid id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id.ToString());
        }
    }
}
