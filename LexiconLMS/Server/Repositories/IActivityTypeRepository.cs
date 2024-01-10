using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories;

public interface IActivityTypeRepository
{
    Task CreateAsync(ActivityType activityType);
    void DeleteAsync(ActivityType activityType);
    Task<IEnumerable<ActivityType>> GetAsync(bool includeAll = false);
    Task<ActivityType?> GetAsync(Guid id);
    void UpdateAsync(ActivityType activityType);
}