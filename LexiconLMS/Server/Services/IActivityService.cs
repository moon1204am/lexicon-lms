using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public interface IActivityService
    {
        Task<ActivityDto> GetActivityAsync(Guid id);
    }
}