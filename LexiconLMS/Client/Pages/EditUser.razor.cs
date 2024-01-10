using LexiconLMS.Client.Services;
using LexiconLMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
namespace LexiconLMS.Client.Pages
{
    public partial class EditUser
    {
        [Inject]
        public ILmsDataService LMSDataService { get; set; } = default!;
        [Parameter]
        public string UserId { get; set; }
        private string updateStatusMessage;

        private List<string> userEmails = new List<string>();
        private Dictionary<Guid, string> users = new Dictionary<Guid, string>();
        private UserDto selectedUser = new UserDto();
        private UpdateUserDto editUserDto = new UpdateUserDto();

        protected override async Task OnInitializedAsync()
        {
           
            try
            {
                var response = await Http.GetAsync("api/users/getall");

                if (response.IsSuccessStatusCode)
                {
                    var userDtos = await response.Content.ReadFromJsonAsync<List<UserDto>>();
                    if (userDtos != null)
                    {
                        users = userDtos.ToDictionary(u => u.Id, u => u.Email);
                    }
                    else
                    {
                        // Handle case where user list is null
                        users = new Dictionary<Guid, string>();
                    }
                }
                else
                {
                    // Handle non-success status code
                    Console.WriteLine($"Error fetching users: {response.StatusCode}");
                    users = new Dictionary<Guid, string>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions during the fetch operation
                Console.WriteLine($"Exception while fetching users: {ex.Message}");
                users = new Dictionary<Guid, string>();
            }
        }

        private async Task OnUserSelected(ChangeEventArgs e)
        {
            if (Guid.TryParse(e.Value?.ToString(), out Guid userId))
            {
                //selectedUser = await Http.GetFromJsonAsync<UserDto>($"api/users/{userId}");
                Console.WriteLine($"Fetching details for user ID: {userId}");
                var user = await Http.GetFromJsonAsync<UserDto>($"api/users/{userId}");
                if (user != null)
                {
                    selectedUser = user;
                    editUserDto.FirstName = user.FirstName;
                    editUserDto.LastName = user.LastName;
                    editUserDto.Email = user.Email;
                }
            }
        }

        private async Task HandleValidSubmit()
        {
            var response = await Http.PutAsJsonAsync($"api/users/update/{selectedUser.Id}", editUserDto);
            if (response.IsSuccessStatusCode)
            {
                updateStatusMessage = "User updated successfully";
                // Optionally, refresh user list or redirect
            }
            else
            {
                updateStatusMessage = "Error updating user";
            }
        }
    }
}
