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
        //private ClaimsPrincipal _user;

        [Inject]
        public ILmsDataService LmsDataService { get; set; } = default!;
        //[Inject]
        //private IUserManager UserManager { }
        //[Inject]
        //private UserManager<IdentityUser> _userManager { get; set; } = default!;
        //[Inject]
        //AuthenticationStateProvider ASProvider { get; set; } = default!;

        [Parameter]
        public Guid CourseId { get; set; }
        public CourseDto? CourseDto { get; set; }
        public bool IsOpen { get; set; }

        protected override async Task OnInitializedAsync()
        {
          
            CourseDto = await LmsDataService.GetAsync<CourseDto>($"api/courses/{CourseId}");
            //var authstate = await ASProvider.GetAuthenticationStateAsync();
            //_user = authstate.User;

        }
    
    }
}
