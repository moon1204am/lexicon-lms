using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class ActivityAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        private ActivityAddDto? _activityToAddDto = new ActivityAddDto();
        private List<ActivityTypeDto> Activitytypes = new List<ActivityTypeDto>();
        private string _successMessage = string.Empty;
        public List<CourseViewDto> Modules { get; set; } = new List<CourseViewDto>();

        public async Task HandleValidSubmit()
        {
            var activity = await LmsDataService.PostAsync<ActivityAddDto>("api/courses/", _activityToAddDto);

            if (activity == null)
            {
                _successMessage = "Activity could not be added";
            }
            else
            {
                _successMessage = "Course added";
            }
        }
    }
}
