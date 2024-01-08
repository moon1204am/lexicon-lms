using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories;

public interface IModuleRepository
{
    Task CreateAsync(Module module);
    void DeleteAsync(Guid id);
    Task<IEnumerable<Module>> GetAsync(bool includeAll = false);
    Task<Module?> GetAsync(Guid id);
    void UpdateAsync(Module module);
}