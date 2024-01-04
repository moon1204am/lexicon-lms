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
        public async Task CreateCourseAsync()
        {
       
            if (_courseToAdd == null)
            {
                _successMessage = "Course not added";
            }
            else
            {
                await LmsDataService.PostAsync<CourseAddDto>("api/courses/",_courseToAdd);
                _successMessage = "Course added";
            }
        }
    }
}
