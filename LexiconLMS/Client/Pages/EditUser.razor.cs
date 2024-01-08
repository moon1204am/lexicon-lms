using LexiconLMS.Client.Services;
using Microsoft.AspNetCore.Components;
namespace LexiconLMS.Client.Pages
{
    public partial class EditUser
    {
        [Inject]
        public ILmsDataService LMSDataService { get; set; } = default!;
        private async Task UpdateUser()
        {
            await LMSDataService.UpdateUser(User);
        }
    }
}
