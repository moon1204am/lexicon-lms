using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace LexiconLMS.Client.Pages
{
    public partial class CourseAdd
    {
        [Inject] 
        public ILmsDataService LmsDataService { get; set; } = default!;
        [Inject]
        public IUserService UserService { get; set; }
        //[Inject]
        //public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private CourseAddDto? _courseToAdd = new CourseAddDto();
        private string _successMessage = string.Empty;
        public string UserId { get; set; }

        public UserManager<IdentityUser> userManager { get; set; }
        private IBrowserFile selectedFile;

        protected async override Task OnInitializedAsync()
        {
            //var user = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User;
            UserId = await UserService.GetCurrentUser();
            //UserId = await UserService.GetCurrentUserId();
        }
        protected async Task CreateCourseAsync()
        {
            if (_courseToAdd == null)
            {
                _successMessage = "Course not added";
            }
            else
            {
                if (selectedFile != null)
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    _courseToAdd.DocumentDto.FileName = file.Name;
                    _courseToAdd.DocumentDto.FileContent = ms.ToArray();
                    _courseToAdd.DocumentDto.FileType = file.ContentType;
                    _courseToAdd.DocumentDto.UploadDate = DateTime.Now;
                    _courseToAdd.DocumentDto.UserId = UserId;
                }

                await LmsDataService.PostAsync<CourseAddDto>("api/courses", _courseToAdd);
                _successMessage = "Course added";
            }
        }
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }
    }
}
