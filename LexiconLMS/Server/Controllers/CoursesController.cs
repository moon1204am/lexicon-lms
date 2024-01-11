using Microsoft.AspNetCore.Mvc;
using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/courses")]
    [ApiController]

    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CoursesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [Authorize(Roles="Admin")]
        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(bool includeAll = false)
        {
            return Ok(await _serviceManager.CourseService.GetCoursesAsync(includeAll));

        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            return Ok((CourseDto?)await _serviceManager.CourseService.GetCourseAsync(id));

        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCourse(Guid id, CourseDto course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            await _serviceManager.CourseService.UpdateCourseAsync(id, course);

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseAddDto? course)
        {
            if (course != null)
            {
                var courseDto = await _serviceManager.CourseService.CreateCourseAsync(course);
                return CreatedAtAction(nameof(GetCourse), new { id = courseDto}, courseDto);
            }
            else
            {
                return BadRequest("Data missing.");
            }
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            await _serviceManager.CourseService.DeleteCourseAsync(id);

            return NoContent();
        }

    }
}
