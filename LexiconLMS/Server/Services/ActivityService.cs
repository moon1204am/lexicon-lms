using AutoMapper;
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

        public async Task<ActivityDto> GetActivityAsync(Guid id)
        {
            return _mapper.Map<ActivityDto>(await _unitOfWork.ActivityRepository.GetActivity(id));
        }
    }
}
