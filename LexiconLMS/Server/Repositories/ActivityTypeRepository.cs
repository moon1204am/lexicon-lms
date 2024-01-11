using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ActivityType>> GetAsync(bool includeAll = false)
        {
            //return includeAll ? await _context.ActivityType.ToListAsync() :
            return await _context.ActivityType.ToListAsync();
        }
        public async Task<ActivityType?> GetAsync(Guid id)
        {
            return await _context.ActivityType.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task CreateAsync(ActivityType activityType)
        {
            await _context.AddAsync(activityType);
        }
        public void Update(ActivityType activityType)
        {
            _context.Update(activityType);
        }
        public void Delete(ActivityType activityType)
        {
            _context.Remove(activityType);
        }
    }
}
