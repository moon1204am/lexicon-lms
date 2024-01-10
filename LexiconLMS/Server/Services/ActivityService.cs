using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityDto>> GetActivitiesAsync()
        {
            return _mapper.Map<IEnumerable<ActivityDto>>(await _unitOfWork.ActivityRepository.GetAllAsync());
        }

        public async Task<ActivityDto?> GetActivityAsync(Guid id)
        {
            return _mapper.Map<ActivityDto>(await _unitOfWork.ActivityRepository.GetAsync(id));
        }

        public async Task<ActivityDto> CreateActivityAsync(ActivityAddDto activityAddDto)
        {
            var activity = _mapper.Map<Activity>(activityAddDto);
            await _unitOfWork.ActivityRepository.CreateAsync(activity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ActivityDto>(activity);
        }

        public async Task DeleteActivityAsync(Guid id)
        {
            var activity = await _unitOfWork.ActivityRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            _unitOfWork.ActivityRepository.Delete(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Guid id, ActivityAddDto activityDto)
        {
            var activity = await _unitOfWork.ActivityRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            var activityToUpdate = _mapper.Map<Activity>(activityDto);
            _unitOfWork.ActivityRepository.Update(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActivityTypeDto>> GetActivityTypesAsync()
        {
            return _mapper.Map <IEnumerable<ActivityTypeDto>>(await _unitOfWork.ActivityRepository.GetTypesAsync());
        }
    }
}
