using AutoMapper;
using LexiconLMS.Shared.Dtos;
namespace LexiconLMS.Server.Services
{
    public interface ICourseService

    {
        Task<IEnumerable<CourseDto>> GetCoursesAsync(bool includeAll = false);
        Task<CourseDto> GetCourseAsync(Guid id);
        Task<CourseDto> CreateCourseAsync(CourseDto courseDto);
        Task UpdateCourseAsync(Guid id, CourseDto courseDto);
        Task DeleteCourseAsync(Guid id);



    }
}
