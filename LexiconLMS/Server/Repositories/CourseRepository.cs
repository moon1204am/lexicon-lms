using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Course course)
        {
            await _context.AddAsync(course);
        }

        public void DeleteAsync(Guid id)
        {
            _context.Remove(id);
        }

        public async Task<IEnumerable<Course>> GetAsync(bool includeAll = false)
        {
            return includeAll ? await _context.Course.Include(c => c.Modules).ThenInclude(m => m.Activities).ThenInclude(a => a.Type).ToListAsync() : 
                await _context.Course.ToListAsync();
        }

        public async Task<Course?> GetAsync(Guid id)
        {    
            var debug = await _context.Course.Include(c => c.Modules).ThenInclude(m => m.Activities).ThenInclude(a => a.Type).FirstOrDefaultAsync(c => c.Id == id);
            return debug;
        }

        public void UpdateAsync(Course course)
        {
            _context.Update(course);
        }


    }
}
