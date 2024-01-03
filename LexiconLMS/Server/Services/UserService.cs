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

            user.UserName = userDto.Email; // Using email as the username
            // Todo: resolve the issue with the course id, right now it is hardcoded
            user.CourseId = new Guid("01276b0c-345c-4dea-0d0d-08dc0b93fb82"); // Default course id
            // Set other necessary properties for ApplicationUser
            var result = await _userManager.CreateAsync(user, "P@ssw0rd"); 

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception($"User creation failed: {string.Join(", ", errors)}");

            }

            // Optionally assign roles here if needed
        }

        // Implement other methods as needed
    }
}
