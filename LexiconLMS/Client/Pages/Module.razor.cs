using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class Module
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Parameter]
        public string ModuleId { get; set; }
        [Parameter]
        public string CourseId { get; set; }
        public ModuleDto? ModuleDto { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ModuleDto = await LmsDataService.GetAsync<ModuleDto>($"api/courses/module/{ModuleId}");
        }
    }
}
