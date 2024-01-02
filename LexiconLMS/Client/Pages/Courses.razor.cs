using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class Courses
    {
        public List<CourseDto>? CourseList = default!;

        [Inject] public ILmsDataService LmsDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            CourseList = (await LmsDataService.GetAsync<List<CourseDto>>("api/courses"))!; //ToDo: fix nullability
        }
    }
}
