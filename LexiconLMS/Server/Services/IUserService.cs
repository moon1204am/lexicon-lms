
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IEnumerable<UserDto>> GetParticipantsAsync(Guid courseId);
        Task<UserDto> GetUserAsync(Guid id);
        Task<UserDto> GetUserAsync(string UserName);
        Task UpdateUserAsync(Guid userId, UpdateUserDto updateUserDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

    }
}