using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LexiconLMS.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        private readonly IUserService _userService;

        public UsersController(IServiceManager serviceManager, IUserService userService)
        {
            _userService = userService;
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync( CreateUserDto userDto)
        {
            await _serviceManager.UserService.CreateUserAsync(userDto);
            if (!ModelState.IsValid)
        {
                return BadRequest(ModelState);
            }
            //return Ok();
            return new OkObjectResult(new { message = "User created successfully", user = userDto });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAsync(Guid id)
        {
            return Ok(await _serviceManager.UserService.GetUsersAsync(id));
            //return Ok(usersDto);
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            return await _serviceManager.UserService.GetRolesAsync();
        }
    }
}
