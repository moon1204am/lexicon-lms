using Microsoft.AspNetCore.Components;
using LexiconLMS.Shared.Dtos;
using LexiconLMS.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LexiconLMS.Client.Pages
{
    public partial class Admin : ComponentBase
    {
        // ILmsDataService is injected in the Admin.razor page.

        protected UserDto newUser = new UserDto();
        protected List<CourseDto> courses = new List<CourseDto>();

        protected override async Task OnInitializedAsync()
        {
            courses = await LmsDataService.GetAsync<List<CourseDto>>("api/courses");

            if (courses.Count > 0)
            {
                newUser.CourseId = courses[0].Id;
            }
        }

        protected async Task HandleValidSubmit()
        {
            await LmsDataService.PostAsync<UserDto, object>("api/users", newUser);
            newUser = new UserDto();
        }
    }
}
