using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using LexiconLMS.Shared.Dtos;
using System.Threading.Tasks;
using System;

namespace LexiconLMS.Client.Services
{
    public class LmsDataService : ILmsDataService
    {
        private readonly HttpClient _httpClient;
        private const string json = "application/json";

        public LmsDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string path, string contentType = json)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var result = JsonSerializer.Deserialize<T>(stream, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return result;
        }

        public async Task<T?> PostAsync<T>(string path, object data, string contentType = json)
        {
            //build the request
            var request = new HttpRequestMessage(HttpMethod.Post, path);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            var jsonContent = JsonSerializer.Serialize(data);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, contentType);
            //send the request
            var response = await _httpClient.PostAsync(path, request.Content);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var result = JsonSerializer.Deserialize<T>(stream, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return result;
            }
            return default(T);
        }

        
        
        public async Task<TResponse?> PostAsyncUser<TRequest, TResponse>(string path, TRequest content, string contentType = json)
        {
            var response = await _httpClient.PostAsJsonAsync(path, content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            //response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Response status code does not indicate success: {response.StatusCode}.");
            }

            if (response.Content == null) return default;
            try
            {
                return await response.Content.ReadFromJsonAsync<TResponse>(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            catch (JsonException)
            {
                return default;
            }
        }

    public async Task PutAsync<T>(string path, object data, string contentType = json)
    {
        //build request
        var request = new HttpRequestMessage(HttpMethod.Put, path);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

        var jsonContent = JsonSerializer.Serialize(data);
        request.Content = new StringContent(jsonContent, Encoding.UTF8, contentType);

        //send request
        var response = await _httpClient.PutAsync(path, request.Content);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync<T>(string path, string contentType = json)
    {
        //build request
        var request = new HttpRequestMessage(HttpMethod.Delete, path);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

        //send request
        var response = await _httpClient.DeleteAsync(path);

        response.EnsureSuccessStatusCode();
    }



    public async Task UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        var response = await _httpClient.PutAsJsonAsync("api/users/update/{userId}", updateUserDto);
        response.EnsureSuccessStatusCode();
    }

}
}
