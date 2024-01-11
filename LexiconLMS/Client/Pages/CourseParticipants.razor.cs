using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Client.Pages
{
    public partial class CourseParticipants
    {
        [Inject]
        public ILmsDataService LmsDataService { get; set; }
        [Parameter]
        public string CourseId { get; set; }
        public List<UserDto> CourseParticipantsList { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            CourseParticipantsList = await LmsDataService.GetAsync<List<UserDto>>($"api/users/participants/{CourseId}");
        }
    }
}
