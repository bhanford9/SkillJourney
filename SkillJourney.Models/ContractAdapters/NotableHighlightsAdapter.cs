using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Models.NotableHighlights;

namespace SkillJourney.Models.ContractAdapters;
public interface INotableHighlightsAdapter
{
    Task<INotableHighlightModel> CreateNotableHighlightForUser(
        Guid receivingUser,
        Guid actingUser,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkillRatings);
    Task<IReadOnlyList<INotableHighlightModel>> GetHighlightsForUser(Guid user);
    INotableHighlightModel ToModel(NotableHighlightContract notableHighlight);
}

internal class NotableHighlightsAdapter : INotableHighlightsAdapter
{
    private readonly INotableHighlightFactory notableHighlightFactory;
    private readonly INotableHighlightsClient notableHighlightsClient;
    private readonly ISkillRatingsAdapter skillRatingsAdapter;

    public NotableHighlightsAdapter(
        INotableHighlightFactory notableHighlightFactory,
        INotableHighlightsClient notableHighlightsClient,
        ISkillRatingsAdapter skillRatingsAdapter)
    {
        this.notableHighlightFactory = notableHighlightFactory;
        this.notableHighlightsClient = notableHighlightsClient;
        this.skillRatingsAdapter = skillRatingsAdapter;
    }

    public async Task<IReadOnlyList<INotableHighlightModel>> GetHighlightsForUser(Guid user) =>
        (await notableHighlightsClient.GetHighlightsForUser(user)).Select(ToModel).ToList();

    public async Task<INotableHighlightModel> CreateNotableHighlightForUser(
        Guid receivingUser,
        Guid actingUser,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkillRatings)
    {
        return ToModel(await notableHighlightsClient.AddHighlight(
            receivingUser,
            actingUser,
            significanceRating,
            description,
            dateOfOccurrence,
            relatedSkillRatings));
    }

    public INotableHighlightModel ToModel(NotableHighlightContract notableHighlight)
        => notableHighlightFactory.CreateNotableHighlight(
            notableHighlight.Id,
            notableHighlight.SignificanceRating,
            notableHighlight.Description,
            notableHighlight.DateOfOccurrence,
            notableHighlight.RelatedSkills.Select(x => skillRatingsAdapter.ToModel(x.SkillRating)).ToList());
}
