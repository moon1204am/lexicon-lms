using AutoMapper;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(Guid courseId)
        {
            //var users = await _unitOfWork.UserRepository.GetParticipantsAsync(courseId);
            //var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            //return usersDto;

            return _mapper.Map<IEnumerable<UserDto>>(await _unitOfWork.UserRepository.GetParticipantsAsync(courseId));
        }
    }
}
