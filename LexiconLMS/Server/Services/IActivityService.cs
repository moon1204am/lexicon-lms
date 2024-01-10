using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public interface IActivityService
    {
        Task<ActivityDto?> GetActivityAsync(Guid id);
        Task<IEnumerable<ActivityDto>> GetActivitiesAsync();
        Task<ActivityDto> CreateActivityAsync(ActivityAddDto activityAddDto);
        Task UpdateActivityAsync(Guid id, ActivityAddDto activity);
        Task DeleteActivityAsync(Guid id);
        Task<IEnumerable<ActivityTypeDto>> GetActivityTypesAsync();
    }
}