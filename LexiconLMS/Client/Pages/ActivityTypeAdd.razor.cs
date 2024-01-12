using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class ActivityTypeAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        private ActivityTypeAddDto? _activityTypeToAdd = new ActivityTypeAddDto();

        public List<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
        protected override async Task OnInitializedAsync()
        {
            Activities = ((await LmsDataService.GetAsync<List<ActivityDto>>("api/activities"))!).ToList();
        }
        public async Task CreateCourseAsync()
        {
            var activityType = await LmsDataService.PostAsync<ActivityTypeAddDto>("api/activitytypes/", _activityTypeToAdd);
            NavigationManager.NavigateTo("/courses");
        }
    }
}
