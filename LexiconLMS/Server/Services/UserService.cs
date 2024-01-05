using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LexiconLMS.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> CreateUserAsync(CreateUserDto userDto)
        {
            var role = await _unitOfWork.UserRepository.GetRoleAsync(userDto.RoleDto.Id);
            var user = _mapper.Map<ApplicationUser>(userDto);
            // Using email as the username
            user.UserName = userDto.Email;

            await _userManager.AddToRoleAsync(user, role.Name);
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

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {        
            var roles = await _unitOfWork.UserRepository.GetRolesAsync(); 
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
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
