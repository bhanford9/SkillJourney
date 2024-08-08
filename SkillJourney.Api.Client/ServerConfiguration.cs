namespace SkillJourney.Api.Client;

internal interface IServerConfiguration
{
    string BaseUrl { get; }
}

internal class ServerConfiguration : IServerConfiguration
{
    public string BaseUrl { get; } = "http://localhost:5008/";
}
