using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LexiconLMS.Client.Pages
{
    public partial class Course
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public Guid CourseId { get; set; }

        public Guid ModuleId { get; set; }
        public CourseDto? CourseDto { get; set; }



        protected override async Task OnInitializedAsync()
        {
            CourseDto = await LmsDataService.GetAsync<CourseDto>($"api/courses/{CourseId}");
        }
        
        public async Task DeleteCourseAsync()
        {
            await LmsDataService.DeleteAsync<Guid>($"api/courses/{CourseId}");
            NavigationManager.NavigateTo("/courses");
        }

        public async Task DeleteModuleAsync()
        {
            await LmsDataService.DeleteAsync<Guid>($"api/modules/{ModuleId}");
            NavigationManager.NavigateTo($"/course/{CourseId}",forceLoad: true);
        }
    }
}
