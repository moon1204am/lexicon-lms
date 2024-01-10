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
        public async Task CreateCourseAsync()
        {

            if (_activityTypeToAdd == null)
            {
                _successMessage = "Course not added";
            }
            else
            {
                await LmsDataService.PostAsync<ActivityTypeAddDto>("api/activitytypes/", _activityTypeToAdd);
                _successMessage = "Course added";
            }
        }
    }
}
