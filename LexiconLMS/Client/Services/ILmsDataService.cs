namespace LexiconLMS.Client.Services;

public interface ILmsDataService
{
    Task<T?> GetAsync<T>(string path, string contentType = "application/json");
    Task<TResponse?> PostAsyncUser<TRequest, TResponse>(string path, TRequest content, string contentType = "application/json");
}