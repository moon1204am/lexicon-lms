using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.AutoMapperConfig
{
    public class LmsMappings : Profile
    {
        public LmsMappings() 
        { 
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
        }
    }
}
