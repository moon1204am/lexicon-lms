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
            CreateMap<Course, CourseViewDto>().ReverseMap();
            CreateMap<Course, CourseAddDto>().ReverseMap();

            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
            
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();

            CreateMap<IdentityRole, RoleDto>().ReverseMap();

            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleViewDto>().ReverseMap();
            CreateMap<Module, ModuleAddDto>().ReverseMap();
        }
    }
}
