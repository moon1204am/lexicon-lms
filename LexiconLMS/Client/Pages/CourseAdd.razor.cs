using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace LexiconLMS.Client.Pages
{
    public partial class CourseAdd
    {
        [Inject] 
        public ILmsDataService LmsDataService { get; set; } = default!;
        private CourseAddDto? _courseToAdd = new CourseAddDto();
        private string _successMessage = string.Empty;
        public async Task HandleValidSubmit()
        {
            var course = await LmsDataService.PostAsync<CourseAddDto>("api/courses/", _courseToAdd);
            if (course == null)
            {
                _successMessage = "Course could not be added";
            }
            else
            {
                _successMessage = "Course added";
            }
        }
    }
}
