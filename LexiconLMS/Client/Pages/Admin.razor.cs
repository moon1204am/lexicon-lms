using Microsoft.AspNetCore.Components;
using LexiconLMS.Shared.Dtos;
using LexiconLMS.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Client.Pages
{
    public partial class Admin : ComponentBase
    {
        // ILmsDataService is injected in the Admin.razor page.

        public CreateUserDto User { get; set; } = new CreateUserDto();
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
        public List<RoleDto> RolesList { get; set; } = new List<RoleDto>();



        protected override async Task OnInitializedAsync()
        {
            RolesList = (await LmsDataService.GetAsync<List<RoleDto>>("api/users/roles")).ToList();

            Courses = (await LmsDataService.GetAsync<List<CourseDto>>("api/courses")).ToList();

            //if (courses.Count > 0)
            //{
            //    newUser.CourseId = courses[0].Id;
            //}
        }

        
        
        
        protected async Task HandleValidSubmit()
        {
            //newUser.RoleId = _roleGuid;
            //await LmsDataService.PostAsyncUser<CreateUserDto, object>("api/users", newUser);
            await LmsDataService.PostAsync<CreateUserDto>("api/users", User);
        }


    }
}
