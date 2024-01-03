using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAsync(Guid id)
        {
            return  Ok( await _serviceManager.UserService.GetUsersAsync(id));
            //return Ok(usersDto);
        }
    }
}
