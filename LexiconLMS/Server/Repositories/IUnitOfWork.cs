using LexiconLMS.Server.Services;

namespace LexiconLMS.Server.Repositories
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IUserRepository UserRepository { get; }

        Task SaveChangesAsync();
    }
}