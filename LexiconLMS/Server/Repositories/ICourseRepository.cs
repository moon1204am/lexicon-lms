using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync(bool includeAll = false);
        Task<Course?> GetAsync(Guid id);
        Task CreateAsync(Course course);
        void Update(Course course);
        void Delete(Course course);
    }
}