using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);

        Task<IEnumerable<Activity>> GetAllAsync();
        
        Task CreateAsync(Activity activity);

        void Delete(Activity activity);

        void Update(Activity activity);
        Task<IEnumerable<ActivityType>> GetTypesAsync();
    }
}