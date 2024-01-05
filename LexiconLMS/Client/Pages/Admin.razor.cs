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

        protected CreateUserDto newUser = new CreateUserDto();
        protected List<CourseDto> courses = new List<CourseDto>();

        private Guid _roleGuid { get; set; } = default!;

        public string Role { get; set; } 
        protected List<RoleDto> rolesList = new List<RoleDto>();



        protected override async Task OnInitializedAsync()
        {
            rolesList = await LmsDataService.GetAsync<List<RoleDto>>("api/users/roles");

            courses = await LmsDataService.GetAsync<List<CourseDto>>("api/courses");

            if (courses.Count > 0)
            {
                newUser.CourseId = courses[0].Id;
            }
        }

        
        
        
        protected async Task HandleValidSubmit()
        {
            var a = _roleGuid;
            newUser.RoleDto = rolesList.FirstOrDefault(x => x.Id == _roleGuid);
            //newUser.RoleId = new Guid(_roleGuid.ToString());
            
            //newUser.RoleId = _roleGuid;
            //await LmsDataService.PostAsyncUser<CreateUserDto, object>("api/users", newUser);
            //var result = newUser;
            while (newUser.RoleDto == null) {
            }
            await LmsDataService.PostAsync<CreateUserDto>("api/users", newUser);
            
        }


    }
}
