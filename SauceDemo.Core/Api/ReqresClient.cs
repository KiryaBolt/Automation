using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace SauceDemo.Core.Api;

public class ReqresClient : IDisposable
{
    public const string DefaultBaseUrl = "https://reqres.in/api/";

    public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private readonly HttpClient _http;

    public ReqresClient(string? apiKey, string baseUrl = DefaultBaseUrl)
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(30)
        };

        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            _http.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }
    }

    public Task<HttpResponseMessage> GetAsync(string path) =>
        _http.GetAsync(path);

    public Task<HttpResponseMessage> PostAsync(string path, object body) =>
        _http.PostAsJsonAsync(path, body, JsonOptions);

    public Task<HttpResponseMessage> PutAsync(string path, object body) =>
        _http.PutAsJsonAsync(path, body, JsonOptions);

    public Task<HttpResponseMessage> PatchAsync(string path, object body) =>
        _http.PatchAsJsonAsync(path, body, JsonOptions);

    public Task<HttpResponseMessage> DeleteAsync(string path) =>
        _http.DeleteAsync(path);

    public static async Task<T> ReadAsync<T>(HttpResponseMessage response)
    {
        var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions);
        return result ?? throw new InvalidOperationException(
            $"Не удалось десериализовать ответ в {typeof(T).Name}");
    }

    public void Dispose() => _http.Dispose();
}