using SkillJourney.Api.Shared.Contract.SkillRatings;

namespace SkillJourney.Api.Client.ApiClients;

public interface ISkillRatingsClient
{
    Task<IReadOnlyList<SkillRatingContract>> GetAllSkillRatings();
}

internal class SkillRatingsClient : ApiClient, ISkillRatingsClient
{
    public SkillRatingsClient(IServerConfiguration serverConfig, HttpClient httpClient) : base(serverConfig, httpClient) { }

    public async Task<IReadOnlyList<SkillRatingContract>> GetAllSkillRatings() =>
        await GetAsync<IReadOnlyList<SkillRatingContract>>("skillratings");
}
