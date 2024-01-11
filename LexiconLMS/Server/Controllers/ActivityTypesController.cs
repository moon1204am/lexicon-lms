using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/activitytypes")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ActivityTypesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTypeDto>>> GetActivityType(bool includeAll = false)
        {
            return Ok(await _serviceManager.ActivityTypeService.GetActivityTypeAsync(includeAll));

        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityTypeDto>> GetActivityType(Guid id)
        {

            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            return Ok((ActivityTypeDto?)await _serviceManager.ActivityTypeService.GetActivityTypeAsync(id));
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutActivityType(Guid id, ActivityTypeDto activityType)
        {
            if (id != activityType.Id)
            {
                return BadRequest();
            }
            await _serviceManager.ActivityTypeService.UpdateActivityTypeAsync(id, activityType);

            return NoContent();
        }

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityTypeDto>> PostActivityType(ActivityTypeAddDto? activityType)
        {
            if (activityType == null)
            {
                return BadRequest("The posted module is empty");
            }
            else
            {
                var activityTypeDto = await _serviceManager.ActivityTypeService.CreateActivityTypeAsync(activityType);
                return CreatedAtAction(nameof(GetActivityType), new { id = activityTypeDto.Id }, activityTypeDto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivityType(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            await _serviceManager.ActivityTypeService.DeleteActivityTypeAsync(id);

            return NoContent();

        }
    }
}
