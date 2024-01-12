using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LexiconLMS.Client.Pages
{
    [Authorize]
    public partial class HomePage
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public CourseDto? CourseDto { get; set; }
        public UserDto? UserDto { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var username = authenticationState.User.Identity?.Name;

            UserDto = await LmsDataService.GetAsync<UserDto>($"api/users/loginuser/{username}");
            CourseDto = await LmsDataService.GetAsync<CourseDto>($"api/courses/{UserDto.CourseId}");
        }
    }
}
