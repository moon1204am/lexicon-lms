using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetParticipantsAsync(Guid courseId);
    }
}