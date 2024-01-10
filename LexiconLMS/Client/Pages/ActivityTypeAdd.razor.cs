using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class ActivityTypeAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        private ActivityTypeAddDto? _activityTypeToAdd = new ActivityTypeAddDto();
        private string _successMessage = string.Empty;

        public List<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
        protected override async Task OnInitializedAsync()
        {
            //Activities = ((await LmsDataService.GetAsync<List<ActivityDto>>("api/activities"))!).ToList();
        }
        public async Task CreateCourseAsync()
        {
            var activityType = await LmsDataService.PostAsync<ActivityTypeAddDto>("api/activitytypes/", _activityTypeToAdd);

            if (activityType == null)
            {
                _successMessage = "Activity type could not be added";
            }
            else
            {
                
                _successMessage = "Activity type added";
            }
        }
    }
}
