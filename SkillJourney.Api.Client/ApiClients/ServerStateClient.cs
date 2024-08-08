namespace SkillJourney.Api.Client.ApiClients;

public interface IServerStateClient
{
    Task<bool> IsConnected();
}

internal class ServerStateClient : ApiClient, IServerStateClient
{
    public ServerStateClient(IServerConfiguration serverConfig, HttpClient httpClient) : base(serverConfig, httpClient) { }

    public async Task<bool> IsConnected() => await GetAsync<bool>("state");
}
