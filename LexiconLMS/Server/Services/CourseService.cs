using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace LexiconLMS.Server.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext context;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.context = context;
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

                Console.WriteLine(context.ChangeTracker.DebugView.LongView);

                _mapper.Map(courseDto, course);

                // Detach existing ActivityType entities
                //foreach (var module in course.Modules)
                //{
                //    foreach (var activity in module.Activities)
                //    {
                //        context.Entry(activity.Type).State = EntityState.Detached;
                //    }
                //}

                // Explicitly set EntityState to Modified
                //context.Entry(course).State = EntityState.Modified;

                //context.ChangeTracker.DetectChanges();
                Console.WriteLine(context.ChangeTracker.DebugView.LongView);


                //BANDAID FOR AVOIDING CREATING DUBLICATED ACTIVITY TYPES
                //foreach (var module in course.Modules)
                //{
                //    module.Activities = new List<Activity>();
                //}

                _unitOfWork.CourseRepository.Update(course);

                Console.WriteLine(context.ChangeTracker.DebugView.LongView);

                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}
