using AutoMapper;
using LexiconLMS.Client.Pages;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Client.Maps
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Activity, ActivityViewDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();

        }
    }
}
