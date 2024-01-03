using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class CourseAdd
    {

        [Inject] 
        public ILmsDataService LmsDataService { get; set; } = default!;
       
        
        private CourseAddDto? CourseToAdd = new CourseAddDto();


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public async Task CreateCourseAsync()
        {
            if (CourseToAdd == null)
            {

            }
            else
            {
                await LmsDataService.GetAsync<List<CourseDto>>($"api/courses/{CourseToAdd}");
            }

        }

    }
}
