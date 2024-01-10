using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> GetAsync(Guid id)
        {
            return await _context.Activity.Include(a => a.Type).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activity.Include(a => a.Type).ToListAsync();
        }

        public async Task CreateAsync(Activity activity)
        {
            await _context.AddAsync(activity);
        }

        public void Delete(Activity activity)
        {
            _context.Activity.Remove(activity);
        }

        public void Update(Activity activity)
        {
            _context.Update(activity);
        }

        public async Task<IEnumerable<ActivityType>> GetTypesAsync()
        {
            return await _context.ActivtyType.ToListAsync();
        }
    }
}
