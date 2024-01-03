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
        private CourseAddDto? CourseToAdd = new CourseAddDto();

        public async Task CreateCourseAsync()
        {
       
            if (CourseToAdd == null)
            {

            }
            else
            {
                await LmsDataService.PostAsync<CourseAddDto>("api/courses/",CourseToAdd);
            }
        }

    }
}
