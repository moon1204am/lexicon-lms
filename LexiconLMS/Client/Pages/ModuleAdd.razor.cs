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

        public async Task HandleValidSubmit()
        {
            var module= await LmsDataService.PostAsync<ModuleAddDto>("api/modules/", _moduleToAdd);

            if (module == null)
            {
                _successMessage = "Module could not be added";
            }
            else
            {
                _successMessage = "Module added";
            }
        }
    }
}
