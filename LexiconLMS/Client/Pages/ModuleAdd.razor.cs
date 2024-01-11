using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class ModuleAdd
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        private ModuleAddDto? _moduleToAdd = new ModuleAddDto();
        public List<CourseViewDto> Courses { get; set; } = new List<CourseViewDto>();


        protected override async Task OnInitializedAsync()
        {
            Courses = ((await LmsDataService.GetAsync<List<CourseViewDto>>("api/courses"))!).ToList();
        }

        public async Task HandleValidSubmit()
        {
            var module= await LmsDataService.PostAsync<ModuleAddDto>("api/modules/", _moduleToAdd);
            NavigationManager.NavigateTo("/courses");
        }
    }
}
