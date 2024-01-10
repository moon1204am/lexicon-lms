namespace LexiconLMS.Server.Repositories
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IUserRepository UserRepository { get; }
        IActivityRepository ActivityRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
        Task SaveChangesAsync();
    }
}