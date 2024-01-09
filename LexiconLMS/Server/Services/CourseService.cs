using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync(bool includeAll = false)
        {
            return _mapper.Map<IEnumerable<CourseDto>>(await _unitOfWork.CourseRepository.GetAsync(includeAll));
        }

        public async Task<CourseDto> GetCourseAsync(Guid id)
        {
            return _mapper.Map<CourseDto>(await _unitOfWork.CourseRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id)));
        }
        public async Task<CourseAddDto> CreateCourseAsync(CourseAddDto courseAddDto)
        {
            var document = _mapper.Map<Document>(courseAddDto.DocumentDto);
            //var document = new Document()
            //{
            //    FileName = courseAddDto.FileName,
            //    FileContent = courseAddDto.FileContent,
            //    FileType = courseAddDto.FileType,
            //    UploadDate = courseAddDto.UploadDate,
            //    UserId = new Guid(courseAddDto.UserId)
            //};

            var course = _mapper.Map<Course>(courseAddDto);
            course.Documents.Add(document);
            await _unitOfWork.CourseRepository.CreateAsync(course);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CourseAddDto>(course);
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            _unitOfWork.CourseRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCourseAsync(Guid id, CourseDto courseDto)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            var courseToUpdate = _mapper.Map(courseDto, course);
            _unitOfWork.CourseRepository.UpdateAsync(courseToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
