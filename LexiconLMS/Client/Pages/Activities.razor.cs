using AutoMapper;
using LexiconLMS.Client.Services;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;


namespace LexiconLMS.Client.Pages
{
    public partial class Activities
    {
        public ActivityViewDto? Activity = default!;

        [Inject] public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject] public IMapper LmsMapper { get; set; }
        [Parameter] public Course Course { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Course.Id = new Guid("c91261b8-1c3e-4b28-3b22-08dc0ba50c16");
            var course = await LmsDataService.GetAsync <List<CourseDto >> ($"api/courses/{Course.Id}");

            Activity = LmsMapper.Map<ActivityViewDto>(course);
        }
    }
}
