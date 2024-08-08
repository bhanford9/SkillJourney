using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.NotableHighlights;

namespace SkillJourney.Api.Server.Apis;

public interface INotableHighlightsApi
{
    Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user);
    Task<NotableHighlightContract> AddHighlight(AddNotableHighlightContract addNotableHighlightContract);
}

internal class NotableHighlightsApi : INotableHighlightsApi
{
    private readonly INotableHighlightController highlightsController;
    private readonly ISkillRatingsApi skillRatingsApi;

    public NotableHighlightsApi(INotableHighlightController highlightController, ISkillRatingsApi skillRatingsApi)
    {
        this.highlightsController = highlightController;
        this.skillRatingsApi = skillRatingsApi;
    }

    public Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user)
        => Task.FromResult(highlightsController.GetUserHighlights(user));

    public Task<NotableHighlightContract> AddHighlight(AddNotableHighlightContract addNotableHighlightContract)
        => Task.FromResult(highlightsController.AddHighlight(addNotableHighlightContract));
}