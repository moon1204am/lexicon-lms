namespace LexiconLMS.Server.Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICourseService> courseService;
        private readonly Lazy<IUserService> userService;

        public ICourseService CourseService => courseService.Value;
        public IUserService UserService => userService.Value;

        public ServiceManager(Lazy<ICourseService> courseService, Lazy<IUserService> userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }
    }
}
