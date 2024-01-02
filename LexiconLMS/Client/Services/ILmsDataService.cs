namespace LexiconLMS.Client.Services;

public interface ILmsDataService
{
    Task<T?> GetAsync<T>(string path, string contentType = "application/json");
}