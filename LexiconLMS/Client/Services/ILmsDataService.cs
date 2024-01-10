using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Client.Services;

public interface ILmsDataService
{
    Task<T?> GetAsync<T>(string path, string contentType = "application/json");
    Task<T?> PostAsync<T>(string path, object data, string contentType = "application/json");
    Task UpdateUser(Guid userId, UpdateUserDto updateUserDto);
}