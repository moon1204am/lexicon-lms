using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);

            // Using email as the username
            user.UserName = userDto.Email; 
            
            // In case you need a hardcoded course id, you can set it here, double check the Guid value in SQL database
            //user.CourseId = new Guid("01276b0c-345c-4dea-0d0d-08dc0b93fb82"); // Default course id

            // Set other necessary properties for ApplicationUser
            var result = await _userManager.CreateAsync(user, "P@ssw0rd"); 

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception($"User creation failed: {string.Join(", ", errors)}");

            }

            return new OkObjectResult(new { message = "User created successfully.", user = userDto });

            // Todo: Add user to role here, first needs to resolve issue with SQL roles
        }

        public async Task<IList<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
         
            if (user == null)
            {
                throw new KeyNotFoundException("User role not found.");
            }
            //return await _userManager.GetRolesAsync(user);
            return new List<string>(await _userManager.GetRolesAsync(user));
        }


    }
}
