using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public Task<CourseDto> CreateCourseAsync(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> GetCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseDto>> GetCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> UpdateCourseAsync(Guid id, CourseDto courseDto)
        {
            throw new NotImplementedException();
        }
    }
}
