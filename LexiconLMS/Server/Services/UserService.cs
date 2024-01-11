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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LexiconLMS.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var role = await _unitOfWork.UserRepository.GetRoleAsync(userDto.RoleId);
            var user = _mapper.Map<ApplicationUser>(userDto);
            // Using email as the username
            user.UserName = userDto.Email;
            var userCreated = await _unitOfWork.UserRepository.CreateUserAsync(user, role);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDto>(userCreated);

        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {        
            var roles = await _unitOfWork.UserRepository.GetRolesAsync(); 
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<IEnumerable<UserDto>> GetParticipantsAsync(Guid courseId)
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _unitOfWork.UserRepository.GetParticipantsAsync(courseId));
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.GetUserAsync(id));
        }

        public async Task<UserDto> GetUserAsync(string UserName)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.GetUserAsync(UserName));
        }

        public async Task UpdateUserAsync(Guid userId, UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null) throw new ArgumentNullException(nameof(updateUserDto));

            var userEntity = await _unitOfWork.UserRepository.GetUserAsync(userId);
            if (userEntity == null) throw new KeyNotFoundException($"User with id {userId} not found, Check UserService.cs");

            _mapper.Map(updateUserDto, userEntity);

            await _unitOfWork.UserRepository.UpdateUserAsync(userEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);

        }
    }
}
