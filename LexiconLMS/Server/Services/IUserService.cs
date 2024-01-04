using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Services
{
    public interface IUserService
    {
        Task<IActionResult> CreateUserAsync(UserDto userDto);
        Task<IList<string>> GetUserRolesAsync(string userId);
    }
}
