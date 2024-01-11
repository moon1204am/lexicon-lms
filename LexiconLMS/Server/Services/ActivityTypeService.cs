using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ActivityTypeDto>> GetActivityTypeAsync(bool includeAll = false)
        {
            return _mapper.Map<IEnumerable<ActivityTypeDto>>(await _unitOfWork.ActivityTypeRepository.GetAsync(includeAll));
        }

        public async Task<ActivityTypeDto> GetActivityTypeAsync(Guid id)
        {
            return _mapper.Map<ActivityTypeDto>(await _unitOfWork.ActivityTypeRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id)));
        }
        public async Task<ActivityTypeDto> CreateActivityTypeAsync(ActivityTypeAddDto activityTypeAddDto)
        {
            var activityType = _mapper.Map<ActivityType>(activityTypeAddDto);
            await _unitOfWork.ActivityTypeRepository.CreateAsync(activityType);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ActivityTypeDto>(activityType);
        }

        public async Task DeleteActivityTypeAsync(Guid id)
        {
            var activityType = await _unitOfWork.ActivityTypeRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            _unitOfWork.ActivityTypeRepository.Delete(activityType);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateActivityTypeAsync(Guid id, ActivityTypeDto activityTypeDto)
        {
            var activityType = await _unitOfWork.ActivityTypeRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            var activityTypeToUpdate = _mapper.Map(activityTypeDto, activityType);
            _unitOfWork.ActivityTypeRepository.Update(activityTypeToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
