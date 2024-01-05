
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task<IActionResult> CreateUserAsync(CreateUserDto userDto);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IEnumerable<UserDto>> GetUsersAsync(Guid courseId);

    }
}