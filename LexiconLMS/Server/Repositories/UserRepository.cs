using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LexiconLMS.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user, IdentityRole role)
        {
            try
            {
                // Set other necessary properties for ApplicationUser
                var result = await _userManager.CreateAsync(user, "P@ssw0rd");
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    throw new Exception($"User creation failed: {string.Join(", ", errors)}");

                }
                else
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public async Task<ApplicationUser> GetUserAsync(Guid id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with id {user.Id} not found.");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.Email;

            // Handle role update logic here, if included

            var result = await _userManager.UpdateAsync(existingUser);
            if (!result.Succeeded)
            {
                var errors = string.Join("\n", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Could not update user: {errors} Check the method inside UserRepository.cs");
            }
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();

            // Probably irrelevant, remove if method above works
            //return await _userManager.Users.ToListAsync();
        }
    }
}
