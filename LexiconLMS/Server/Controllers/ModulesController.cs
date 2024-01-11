using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using LexiconLMS.Server.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Module = LexiconLMS.Domain.Entities.Module;

namespace LexiconLMS.Server.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ModulesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules(bool includeAll = false)
        {
            return Ok(await _serviceManager.ModuleService.GetModulesAsync(includeAll));

        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetModule(Guid id)
        {

            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            return Ok((ModuleDto?)await _serviceManager.ModuleService.GetModuleAsync(id));
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutModule(Guid id, ModuleDto course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            await _serviceManager.ModuleService.UpdateModuleAsync(id, course);

            return NoContent();
        }

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModuleDto>> PostModule(ModuleAddDto? module)
        {
            if (module == null)
            {
                return BadRequest("The posted module is empty");
            }
            else
            {
                var moduleDto = await _serviceManager.ModuleService.CreateModuleAsync(module);
                return CreatedAtAction(nameof(GetModule), new { id = moduleDto.Id}, moduleDto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModule(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The input for module ID is missing.");
            }

            await _serviceManager.ModuleService.DeleteModuleAsync(id);

            return NoContent();

        }
    }
}
