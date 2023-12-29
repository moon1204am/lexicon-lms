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
            CreateMap<Activity, ActivityDto>().ForMember(dest => dest.ActivityTypeName, from => from.MapFrom(n => n.Type.Name)).ReverseMap();
            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
        }
    }
}
