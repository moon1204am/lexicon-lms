
using LexiconLMS.Server.Data;

namespace LexiconLMS.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly Lazy<ICourseRepository> _courseRepository;
        public ICourseRepository CourseRepository => _courseRepository.Value;
        
        private readonly Lazy<IUserRepository> _userRepository;
        public IUserRepository UserRepository => _userRepository.Value;
        
        private readonly Lazy<IActivityRepository> _activityRepository;
        public IActivityRepository ActivityRepository => _activityRepository.Value;

        private readonly Lazy<IModuleRepository> _moduleRepository;
        public IModuleRepository ModuleRepository => _moduleRepository.Value;

        public UnitOfWork(ApplicationDbContext context, Lazy<ICourseRepository> courseRepository, Lazy<IUserRepository> userRepository, Lazy<IActivityRepository> activityRepository, Lazy<IModuleRepository> moduleRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _activityRepository = activityRepository;
            _moduleRepository = moduleRepository;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}


