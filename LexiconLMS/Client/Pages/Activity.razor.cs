using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class Activity
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Parameter]
        public Guid ActivityId { get; set; }
        [Parameter]
        public Guid CourseId { get; set; }
        public ActivityDto? ActivityDto { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ActivityDto = await LmsDataService.GetAsync<ActivityDto>($"api/activities/{ActivityId}");
        }
    }
}
