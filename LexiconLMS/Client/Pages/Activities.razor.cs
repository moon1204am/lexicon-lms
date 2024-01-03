using AutoMapper;
using LexiconLMS.Client.Services;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;


namespace LexiconLMS.Client.Pages
{
    public partial class Activities
    {
        public ActivityDto? Activity = default!;
        [Inject] public IMapper Mapper { get; set; } = default!;
        [Inject] public ILmsDataService LmsDataService { get; set; } = default!;
        [Parameter] public Course Course { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            //Course.Id = new Guid("5c3283dc-86da-4fb9-f460-08dc0b9a619a");
            var course = (await LmsDataService.GetAsync<Course>($"api/courses/{new Guid("5c3283dc-86da-4fb9-f460-08dc0b9a619a")}"))!;
           
            Activity = Mapper.Map<ActivityDto>(course.Modules?.FirstOrDefault()?.Activities?.FirstOrDefault());
        }
    }
}
