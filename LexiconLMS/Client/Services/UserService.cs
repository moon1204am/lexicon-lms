using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;

namespace LexiconLMS.Client.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetCurrentUser()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
