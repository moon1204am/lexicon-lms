namespace LexiconLMS.Server.Services
{
    public interface IServiceManager
    {
        ICourseService CourseService { get; }
        IUserService UserService { get; }
        IActivityService ActivityService { get; }
        IModuleService ModuleService { get; }
        IActivityTypeService ActivityTypeService { get; }
    }
}