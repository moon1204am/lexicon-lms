using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class Courses
    {
        public List<CourseDto>? courses = default!;

        [Inject] public ILmsDataService LmsDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            courses = (await LmsDataService.GetAsync<List<CourseDto>>("api/courses"))!; //ToDo: fix nullability
        }
    }
}
