using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetActivity(Guid id);
    }
}