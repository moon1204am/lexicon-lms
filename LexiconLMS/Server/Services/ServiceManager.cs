using LexiconLMS.Server.Services;
using System;

namespace LexiconLMS.Server.Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICourseService> _courseService;
        public ICourseService CourseService => _courseService.Value;
        private readonly Lazy<IUserService> _userService;
        public IUserService UserService => _userService.Value;
        private readonly Lazy<IActivityService> _activityService;
        public IActivityService ActivityService => _activityService.Value;

        public ServiceManager(
            Lazy<ICourseService> courseService, 
            Lazy<IUserService> userService, 
            Lazy<IActivityService> activityService)
        {
            _courseService = courseService;
            _userService = userService;
            _activityService = activityService;
        }
    }
}