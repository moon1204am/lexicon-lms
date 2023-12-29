using AutoMapper;
using LexiconLMS.Shared.Dtos;
namespace LexiconLMS.Server.Services
{
    public interface ICourseService

    {
        Task<IEnumerable<CourseDto>> GetCoursesAsync();
        Task<CourseDto> GetCourseAsync(Guid id);
        Task<CourseDto> CreateCourseAsync(CourseDto courseDto);
        Task<CourseDto> UpdateCourseAsync(Guid id, CourseDto courseDto);
        Task<bool> DeleteCourseAsync(Guid id);



    }
}
