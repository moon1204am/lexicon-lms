using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace LexiconLMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class CourseAdd
    {
        [Inject] 
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        private CourseAddDto? _courseToAdd = new CourseAddDto();
        
        public async Task HandleValidSubmit()
        {
            var course = await LmsDataService.PostAsync<CourseAddDto>("api/courses/", _courseToAdd);
            NavigationManager.NavigateTo("/courses");
        }
    }
}
