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
            return _mapper.Map<IEnumerable<CourseDto>>(await _unitOfWork.CourseRepository.GetAllAsync(includeAll));
        }

        public async Task<CourseDto?> GetCourseAsync(Guid id)
        {
            return _mapper.Map<CourseDto>(await _unitOfWork.CourseRepository.GetAsync(id));
        }
        public async Task<CourseDto> CreateCourseAsync(CourseAddDto courseAddDto)
        {
            var course = _mapper.Map<Course>(courseAddDto);
            await _unitOfWork.CourseRepository.CreateAsync(course);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCourseAsync(Guid id, CourseDto courseDto)
        {
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));

                var courseToUpdate = _mapper.Map(courseDto, course);

                //BANDAID FOR AVOIDING CREATING DUBLICATED ACTIVITY TYPES
                //foreach (var module in courseToUpdate.Modules)
                //{
                //    module.Activities = new List<Activity>();
                //}

                _unitOfWork.CourseRepository.Update(courseToUpdate);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}
