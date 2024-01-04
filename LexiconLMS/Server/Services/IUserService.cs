
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync(Guid courseId);
    }
}