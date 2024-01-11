using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class ActivityAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        private ActivityAddDto? _activityToAddDto = new ActivityAddDto();
        private List<ActivityTypeDto> ActivityTypes = new List<ActivityTypeDto>();
        [Parameter]
        public Guid ModuleId { get; set; }
        public List<CourseViewDto> Modules { get; set; } = new List<CourseViewDto>();

        protected override async Task OnInitializedAsync()
        {
            ActivityTypes = await LmsDataService.GetAsync<List<ActivityTypeDto>>("api/activities/types");
            _activityToAddDto.ModuleId = ModuleId;
        }        

        public async Task HandleValidSubmit()
        {
            var activity = await LmsDataService.PostAsync<ActivityAddDto>("api/activities", _activityToAddDto);
            NavigationManager.NavigateTo("/courses");
        }
    }
}
