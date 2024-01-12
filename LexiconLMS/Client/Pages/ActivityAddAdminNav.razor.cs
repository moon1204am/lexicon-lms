using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class ActivityAddAdminNav
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        private ActivityAddDto? _activityToAddDto = new ActivityAddDto();
        private List<ActivityTypeDto> ActivityTypes = new List<ActivityTypeDto>();
        private List<CourseDto> Courses = new List<CourseDto>();
        private string _successMessage = string.Empty;
        [Parameter]
        public Guid ModuleId { get; set; }
        private Guid _courseId { get; set; }
        public List<ModuleDto> Modules { get; set; } = new List<ModuleDto>();

        protected override async Task OnInitializedAsync()
        {
            ActivityTypes = await LmsDataService.GetAsync<List<ActivityTypeDto>>("api/activities/types");
            Courses = (await LmsDataService.GetAsync<List<CourseDto>>("api/courses")).ToList();
           
            //foreach (var course in Courses)
            //{
            //    Modules = course.Modules.ToList();
            //}

            _activityToAddDto.ModuleId = ModuleId;
        }

        public async Task HandleValidSubmit()
        {
            var activity = await LmsDataService.PostAsync<ActivityAddDto>("api/activities", _activityToAddDto);

            if (activity == null)
            {
                _successMessage = "Activity could not be added";
            }
            else
            {
                _successMessage = "Activity added";
            }
        }
    }
}
