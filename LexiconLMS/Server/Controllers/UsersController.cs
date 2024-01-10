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

        // Note: Added ("{id}") to the route in order to resolve the error with 'GetAllUsers()' method signature.
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateUserDto>> GetUser(Guid id)
        {
            return Ok(await _serviceManager.UserService.GetUserAsync(id));
        }

        // Note: Added ("participants/") to the route in order to resolve the error with 'GetAllUsers()' method signature.
        [HttpGet("participants/{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> PutParticipants(Guid id)
        {
            return Ok(await _serviceManager.UserService.GetParticipantsAsync(id));
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            return await _serviceManager.UserService.GetRolesAsync();
        }


        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromBody] UpdateUserDto updateUserDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serviceManager.UserService.UpdateUserAsync(userId, updateUserDto);
                return Ok();
            }

            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the user. Check UsersController.cs");
            }
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _serviceManager.UserService.GetAllUsersAsync();
            return Ok(users);
        }

        //// Hardcoded user data for testing
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        //{
        //    // Hardcoded user data for testing
        //    var hardcodedUsers = new List<UserDto>
        //    {
        //        new UserDto
        //        {
        //            Id = Guid.NewGuid(),
        //            FirstName = "John",
        //            LastName = "Doe",
        //            Email = "john.doe@example.com",
        //            // Include other necessary fields as per your UserDto structure
        //        }
        //    };

        //    return Ok(hardcodedUsers);
        //}

    }
}
