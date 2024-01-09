using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Module module)      
        {
            await _context.AddAsync(module);
        }

        public void DeleteAsync(Module module)
        {
            _context.Module.Remove(module);
        }
        public async Task<IEnumerable<Module>> GetAsync(bool includeAll = false)
        {
            return includeAll ? await _context.Module.Include(a => a.Activities).ThenInclude(t => t.Type).ToListAsync() :
                await _context.Module.ToListAsync();
        }

        public async Task<Module?> GetAsync(Guid id)
        {
            return await _context.Module.Include(a => a.Activities).ThenInclude(t => t.Type).FirstOrDefaultAsync(m => m.Id == id);
        }

        public void UpdateAsync(Module module)
        {
            _context.Update(module);
        }
    }
}
