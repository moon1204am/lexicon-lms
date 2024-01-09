using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services;

public interface IModuleService
{
    Task<IEnumerable<ModuleDto>> GetModulesAsync(bool includeAll = false);
    Task<ModuleDto> GetModuleAsync(Guid id);
    Task<ModuleAddDto> CreateModuleAsync(ModuleAddDto moduleAddDto);
    Task DeleteModuleAsync(Guid id);
    Task UpdateModuleAsync(Guid id, ModuleDto moduleDto);
}