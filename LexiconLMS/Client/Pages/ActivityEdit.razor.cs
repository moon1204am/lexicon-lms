using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class ActivityEdit
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        public List<ActivityTypeDto> ActivityTypes = new List<ActivityTypeDto>();
        [Inject]
        NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public string ActivityId { get; set; }
        public ActivityDto? ActivityDto { get; set; } = new ActivityDto();

        protected override async Task OnInitializedAsync()
        {
            ActivityTypes = await LmsDataService.GetAsync<List<ActivityTypeDto>>("api/activities/types");
            ActivityDto = await LmsDataService.GetAsync<ActivityDto>($"api/activities/{ActivityId}");
        }

        public async Task HandleValidSubmit()
        {
            await LmsDataService.PutAsync<CourseDto>($"api/activities/{ActivityId}", ActivityDto);
            NavigationManager.NavigateTo($"/courses");
        }
    }
}
