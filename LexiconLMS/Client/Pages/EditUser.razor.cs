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

        protected override async Task OnInitializedAsync()
        {
            #region
            //    //var userDtos = await Http.GetFromJsonAsync<List<UserDto>>("api/users");
            //    //users = userDtos.ToDictionary(u => u.Id, u => u.Email);

            //    var response = await Http.GetAsync("api/users");


            //    if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            //    {
            //        var userDtos = await response.Content.ReadFromJsonAsync<List<UserDto>>();
            //        users = userDtos.ToDictionary(u => u.Id, u => u.Email);
            //    }
            //    else
            //    {
            //        // Handle empty or null response (e.g., by initializing 'users' as an empty dictionary)
            //        users = new Dictionary<Guid, string>();
            //    }
            #endregion
            
            try
            {
                var response = await Http.GetAsync("api/users");

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
                selectedUser = await Http.GetFromJsonAsync<UserDto>($"api/users/{userId}");
            }
        }

        private async Task HandleValidSubmit()
        {
            var response = await Http.PutAsJsonAsync($"api/users/{selectedUser.Id}", selectedUser);
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
