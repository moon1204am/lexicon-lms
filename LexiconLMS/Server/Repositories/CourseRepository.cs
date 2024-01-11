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

        public void Delete(Course course)
        {
            _context.Remove(course);
        }

        public async Task<IEnumerable<Course>> GetAllAsync(bool includeAll = false)
        {
            return includeAll ? await _context.Course.Include(c => c.Modules).ThenInclude(m => m.Activities).ThenInclude(a => a.Type).ToListAsync() : 
                await _context.Course.ToListAsync();
        }

        public async Task<Course?> GetAsync(Guid id)
        {           
            return await _context.Course.Include(c => c.Modules).ThenInclude(m => m.Activities).ThenInclude(a => a.Type).FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Update(Course course)
        {
            _context.Update(course);
        }
    }
}
