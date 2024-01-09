using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class ModuleAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        private ModuleAddDto? _moduleToAdd = new ModuleAddDto();
        private string _successMessage = string.Empty;
        public List<CourseViewDto> Courses { get; set; } = new List<CourseViewDto>();


        protected override async Task OnInitializedAsync()
        {
            Courses = ((await LmsDataService.GetAsync<List<CourseViewDto>>("api/courses"))!).ToList();
        }

        public async Task CreateCourseAsync()
        {

            if (_moduleToAdd == null)
            {
                _successMessage = "Module not added";
            }
            else
            {
                await LmsDataService.PostAsync<ModuleAddDto>("api/modules/", _moduleToAdd);
                _successMessage = "Module added";
            }
        }
    }
}
