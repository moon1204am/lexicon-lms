using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class CourseEdit
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;


        [Parameter]
        public string CourseId { get; set; }
        public CourseDto? CourseDto { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseDto = await LmsDataService.GetAsync<CourseDto>($"api/courses/{CourseId}");
        }

        public async Task UpdateCourseAsync()
        { 
           await LmsDataService.PutAsync<CourseDto>($"api/courses/{CourseId}", CourseDto);
           NavigationManager.NavigateTo("/courses");
        }
    }
}
