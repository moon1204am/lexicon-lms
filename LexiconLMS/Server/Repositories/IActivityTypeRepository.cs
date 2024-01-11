using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories;

public interface IActivityTypeRepository
{
    Task CreateAsync(ActivityType activityType);
    void Delete(ActivityType activityType);
    Task<IEnumerable<ActivityType>> GetAsync(bool includeAll = false);
    Task<ActivityType?> GetAsync(Guid id);
    void Update(ActivityType activityType);
}