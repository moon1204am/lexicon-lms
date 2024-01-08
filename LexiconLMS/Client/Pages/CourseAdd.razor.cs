using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net;

namespace LexiconLMS.Client.Pages
{
    public partial class CourseAdd
    {
        [Inject] 
        public ILmsDataService LmsDataService { get; set; } = default!;
        private CourseAddDto? _courseToAdd = new CourseAddDto();
        private string _successMessage = string.Empty;
        private IBrowserFile selectedFile;
        public async Task CreateCourseAsync()
        {
       
            if (_courseToAdd == null)
            {
                _successMessage = "Course not added";
            }
            else
            {
                await LmsDataService.PostAsync<CourseAddDto>("api/courses/",_courseToAdd);
                _successMessage = "Course added";
            }
        }
        protected async Task HandleValidSubmit()
        {
            if (selectedFile != null)
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                _courseToAdd.FileName = file.Name;
                _courseToAdd.FileContent = ms.ToArray();
            }

            if (_courseToAdd == null)
            {
                _successMessage = "Course not added";
            }
            else
            {
                await LmsDataService.PostAsync<CourseAddDto>("api/courses/", _courseToAdd);
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
