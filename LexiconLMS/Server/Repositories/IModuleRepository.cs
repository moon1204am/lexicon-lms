using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories;

public interface IModuleRepository
{
    Task CreateAsync(Module module);
    void Delete(Module module);
    Task<IEnumerable<Module>> GetAllAsync(bool includeAll = false);
    Task<Module?> GetAsync(Guid id);
    void Update(Module module);
}