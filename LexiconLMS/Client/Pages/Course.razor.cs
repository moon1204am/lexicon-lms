using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class Course
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Parameter]
        public string CourseId { get; set; }
        public CourseDto? CourseDto { get; set; }
        public bool IsOpen { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseDto = await LmsDataService.GetAsync<CourseDto>($"api/courses/{CourseId}");
        }
    }
}
