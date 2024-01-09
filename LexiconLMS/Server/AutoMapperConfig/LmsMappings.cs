using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.AutoMapperConfig
{
    public class LmsMappings : Profile
    {
        public LmsMappings() 
        { 
            //ToDo: Evaluate and remove unused DTOs and mappings.
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CoursesViewDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
            CreateMap<Course, CourseAddDto>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<UpdateUserDto, ApplicationUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                // Ensure that the ID is not being mapped and modified
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); // If UserName is mapped from Email


        }
    }
}
