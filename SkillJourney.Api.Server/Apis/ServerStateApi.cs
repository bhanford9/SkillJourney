namespace SkillJourney.Api.Server.Apis;

public interface IServerStateApi
{
    Task<bool> GetState();
}

internal class ServerStateApi : IServerStateApi
{
    public Task<bool> GetState() => Task.FromResult(true);
}
