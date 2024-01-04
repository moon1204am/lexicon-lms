using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LexiconLMS.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            await _userService.CreateUserAsync(userDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //return Ok();
            return new OkObjectResult(new { message = "User created successfully", user = userDto });
        }

        [Authorize]
        [HttpGet("roles")]
        public async Task<IActionResult> GetUserRolesAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var roles = await _userService.GetUserRolesAsync(userId);
            return Ok(roles);
        }
    }
}
