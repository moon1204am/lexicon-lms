using LexiconLMS.Domain.Entities;

namespace LexiconLMS.Server.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAsync(bool includeAll = false);
        Task<Course?> GetAsync(Guid id);
        Task CreateAsync(Course course);
        void UpdateAsync(Course course);
        void DeleteAsync(Course course);
    }
}