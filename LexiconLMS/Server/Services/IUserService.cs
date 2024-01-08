
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IEnumerable<UserDto>> GetParticipantsAsync(Guid courseId);
        Task<CreateUserDto> GetUserAsync(Guid id);
        Task UpdateUserAsync(UserDto userDto);

    }
}