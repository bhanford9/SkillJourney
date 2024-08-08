using SkillJourney.Api.Shared.Contract.NotableHighlights;

namespace SkillJourney.Api.Client.ApiClients;

public interface INotableHighlightsClient
{
    Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user);
    Task<NotableHighlightContract> AddHighlight(
        Guid receivingUserId,
        Guid actingUserId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkillRatings);
}

internal class NotableHighlightsClient : ApiClient, INotableHighlightsClient
{
    public NotableHighlightsClient(IServerConfiguration serverConfig, HttpClient httpClient) : base(serverConfig, httpClient) { }

    public async Task<NotableHighlightContract> AddHighlight(
        Guid receivingUser,
        Guid actingUser,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkillRatings) => await PostAsync<AddNotableHighlightContract, NotableHighlightContract>(
            "add-highlight",
            new AddNotableHighlightContract(
                receivingUser,
                actingUser,
                significanceRating,
                description,
                dateOfOccurrence,
                relatedSkillRatings));

    public async Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user) =>
        await GetByIdAsync<IReadOnlyList<NotableHighlightContract>>("highlights", user);

}

