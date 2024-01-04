using Microsoft.AspNetCore.Components;
using LexiconLMS.Shared.Dtos;
using LexiconLMS.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LexiconLMS.Client.Pages
{
    public partial class Admin : ComponentBase
    {
        // ILmsDataService is injected in the Admin.razor page.
        IEnumerable<Claim> Claims { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        protected UserDto newUser = new UserDto();
        protected List<CourseDto> courses = new List<CourseDto>();
        protected List<string> userRoles;

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            Claims = authState.User.Claims;
            
            if (authState.User.IsInRole("Admin"))
            {
                Console.WriteLine("User is in Admin role");
            }
            else
            {
                Console.WriteLine("User is not in Admin role");
            }

            try
            {


                courses = await LmsDataService.GetAsync<List<CourseDto>>("api/courses");

                if (courses.Count > 0)
                {
                    newUser.CourseId = courses[0].Id;
                }

                userRoles = await Http.GetFromJsonAsync<List<string>>("api/users/roles");
                Console.WriteLine($"User roles: {userRoles?.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user roles on the Client side:{ex.Message}");
            }
        }

        protected async Task HandleValidSubmit()
        {
            await LmsDataService.PostAsync<UserDto, object>("api/users", newUser);
            newUser = new UserDto();
        }
    }
}
