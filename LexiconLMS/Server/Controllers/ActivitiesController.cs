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
    [Route("api/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ActivitiesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivities()
        {
            return Ok(await _serviceManager.ActivityService.GetActivitiesAsync());

        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivity(Guid id)
        {

            if (id == Guid.Empty)
            {
                return BadRequest("The input for activity ID is missing.");
            }

            return Ok((ActivityDto?)await _serviceManager.ActivityService.GetActivityAsync(id));
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutActivity(Guid id, ActivityAddDto activityDto)
        {
            //if (id != activityDto.Id)
            //{
            //    return BadRequest();
            //}
            await _serviceManager.ActivityService.UpdateActivityAsync(id, activityDto);

            return NoContent();
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityDto>> PostActivity(ActivityAddDto? activity)
        {
            if (activity == null)
            {
                return BadRequest("The posted activity is empty");
            }
            else
            {
                var activityDto = await _serviceManager.ActivityService.CreateActivityAsync(activity);
                return CreatedAtAction(nameof(GetActivity), new { id = activityDto.Id }, activityDto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The input for activity ID is missing.");
            }

            await _serviceManager.ActivityService.DeleteActivityAsync(id);

            return NoContent();

        }

        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<IEnumerable<ActivityTypeDto>>> GetActivityTypes()
        {
            return Ok(await _serviceManager.ActivityService.GetActivityTypesAsync());

        }
    }
}
