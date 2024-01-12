using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LexiconLMS.Client.Pages
{
    [Authorize]
    public partial class Course
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Parameter]
        public Guid CourseId { get; set; }

        public CourseDto? CourseDto { get; set; }

        public Guid ModuleId { get; set; }
        public UserDto? UserDto { get; set; }



        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var username = authenticationState.User.Identity?.Name;

            UserDto = await LmsDataService.GetAsync<UserDto>($"api/users/loginuser/{username}");
            var course = await LmsDataService.GetAsync<CourseDto>($"api/courses/{UserDto.CourseId}");
            if (UserDto.CourseId == null)
            {
                NavigationManager.NavigateTo($"/", forceLoad: true);
            }
            if (UserDto.Role == "Admin" || (UserDto.CourseId == course.Id))
            {
                CourseDto = course;
            }

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
