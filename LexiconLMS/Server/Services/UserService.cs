using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            // Set other necessary properties for ApplicationUser
            var result = await _userManager.CreateAsync(user, "P@ssw0rd"); 

            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }

            // Optionally assign roles here if needed
        }

        // Implement other methods as needed
    }
}
