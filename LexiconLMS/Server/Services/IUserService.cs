using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserDto userDto);
    }
}
