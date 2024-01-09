using System.Security.Claims;

namespace LexiconLMS.Client.Services
{
    public interface IUserService
    {
        Task<string> GetCurrentUser();
    }
}