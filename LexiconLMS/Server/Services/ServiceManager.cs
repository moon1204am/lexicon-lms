namespace LexiconLMS.Server.Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICourseService> _courseService;
        public ICourseService CourseService => _courseService.Value;
        private readonly Lazy<IUserService> _userService;
        public IUserService UserService => _userService.Value;

        public ServiceManager(Lazy<ICourseService> courseService, Lazy<IUserService> userService)
        {
            _courseService = courseService;
            _userService = userService;
        }
    }
}
