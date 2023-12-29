namespace LexiconLMS.Server.Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICourseService> courseService;
        public ICourseService CourseService => courseService.Value;

        public ServiceManager(Lazy<ICourseService> courseService)
        {
            this.courseService = courseService;
        }
    }
}
