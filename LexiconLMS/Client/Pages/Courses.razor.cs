using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class Courses
    {
        public List<CourseViewDto>? CourseList = default!;

        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            CourseList = (await LmsDataService.GetAsync<List<CourseViewDto>>("api/courses"))!;
        }
    }
}
