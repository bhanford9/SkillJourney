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
    INotableHighlightModel ToModel(NotableHighlightContract notableHighlight);
}

internal class NotableHighlightsAdapter : INotableHighlightsAdapter
{
    private readonly INotableHighlightFactory notableHighlightFactory;
    private readonly INotableHighlightsClient notableHighlightsClient;
    private readonly ISkillRatingsAdapter skillRatingsAdapter;
    private readonly IUsersAdapter usersAdapter;

    public NotableHighlightsAdapter(
        INotableHighlightFactory notableHighlightFactory,
        INotableHighlightsClient notableHighlightsClient,
        ISkillRatingsAdapter skillRatingsAdapter,
        IUsersAdapter usersAdapter)
    {
        this.notableHighlightFactory = notableHighlightFactory;
        this.notableHighlightsClient = notableHighlightsClient;
        this.skillRatingsAdapter = skillRatingsAdapter;
        this.usersAdapter = usersAdapter;
    }

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
