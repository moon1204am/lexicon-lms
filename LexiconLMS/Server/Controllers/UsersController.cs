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

        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto createUserDto)
        {
            var userDto = await _serviceManager.UserService.CreateUserAsync(createUserDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }

        [HttpGet]
        public async Task<ActionResult<CreateUserDto>> GetUser(Guid id)
        {
            return Ok(await _serviceManager.UserService.GetUserAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> PutParticipants(Guid id)
        {
            return Ok(await _serviceManager.UserService.GetParticipantsAsync(id));
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            return await _serviceManager.UserService.GetRolesAsync();
        }
    }
}
