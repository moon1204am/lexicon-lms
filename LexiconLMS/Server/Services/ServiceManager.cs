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
        private readonly Lazy<IModuleService> _moduleService;
        public IModuleService ModuleService => _moduleService.Value;
        private readonly Lazy<IActivityTypeService> _activityTypeService;
        public IActivityTypeService ActivityTypeService => _activityTypeService.Value;

        public ServiceManager(
            Lazy<ICourseService> courseService, 
            Lazy<IUserService> userService, 
            Lazy<IActivityService> activityService,
            Lazy<IModuleService> moduleService,
            Lazy<IActivityTypeService> activityTypeService)
        {
            _courseService = courseService;
            _userService = userService;
            _activityService = activityService;
            _moduleService = moduleService;
            _activityTypeService = activityTypeService;
        }
    }
}