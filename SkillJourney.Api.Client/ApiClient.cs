using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SkillJourney.Api.Client;
internal abstract class ApiClient
{
    protected readonly HttpClient httpClient;
    protected readonly IServerConfiguration serverConfig;

    private readonly JsonSerializerOptions jsonSettings =
        new() { PropertyNameCaseInsensitive = true };

    protected ApiClient(IServerConfiguration serverConfig, HttpClient httpClient)
    {
        this.httpClient = httpClient;
        this.serverConfig = serverConfig;
    }

    protected async Task<T> GetAsync<T>(string path)
    {
        try
        {
            var response = await httpClient.GetAsync(new Uri($"{this.serverConfig.BaseUrl}{path}"));
            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(stringContent, jsonSettings)!;
        }
        catch
        {
            // TODO
            return await Task.FromResult(default(T));
        }
    }

    protected async Task<T> GetByIdAsync<T>(string path, Guid id)
    {
        try
        {
            var response = await httpClient.GetAsync(new Uri($"{this.serverConfig.BaseUrl}{path}/{id}"));
            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(stringContent, jsonSettings)!;
        }
        catch
        {
            // TODO
            return await Task.FromResult(default(T));
        }
    }

    protected Task<T> PostAsync<T>(string path, T data) => PostAsync<T, T>(path, data);

    protected async Task<TOut> PostAsync<TIn, TOut>(string path, TIn data)
    {
        try
        {
            HttpContent content = new StringContent(
                JsonSerializer.Serialize(data, jsonSettings),
                Encoding.UTF8,
                "application/json");
            var response = await httpClient.PostAsync(new Uri($"{this.serverConfig.BaseUrl}{path}"), content);
            return (await response.Content.ReadFromJsonAsync<TOut>())!;
        }
        catch
        {
            // TODO
            await Task.CompletedTask;
        }
        
        return default;
    }
}
