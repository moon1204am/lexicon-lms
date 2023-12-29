
using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<ICourseRepository> _courseRepository;
        public ICourseRepository CourseRepository => _courseRepository.Value;
        public UnitOfWork(ApplicationDbContext context, Lazy<ICourseRepository> courseRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
