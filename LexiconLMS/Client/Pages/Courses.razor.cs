using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class Courses
    {
        public List<CourseViewDto>? CourseList = default!;

        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;

        private Guid id;
        protected override async Task OnInitializedAsync()
        {
            CourseList = (await LmsDataService.GetAsync<List<CourseViewDto>>("api/courses"))!; //ToDo: fix nullability
        }

        public async Task DeleteCourseAsync()
        { 
           await LmsDataService.DeleteAsync<Guid>($"api/courses/{id}");
        }
    }
}
