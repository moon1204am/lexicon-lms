using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services;

public interface IActivityTypeService
{
    Task<IEnumerable<ActivityTypeDto>> GetActivityTypeAsync(bool includeAll = false);
    Task<ActivityTypeDto> GetActivityTypeAsync(Guid id);
    Task<ActivityTypeDto> CreateActivityTypeAsync(ActivityTypeAddDto activityTypeAddDto);
    Task DeleteActivityTypeAsync(Guid id);
    Task UpdateActivityTypeAsync(Guid id, ActivityTypeDto activityTypeDto);
}