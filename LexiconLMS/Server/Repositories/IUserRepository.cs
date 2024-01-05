using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetParticipantsAsync(Guid courseId);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
        Task<IdentityRole> GetRoleAsync(Guid id);
    }
}