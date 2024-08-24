using SkillJourney.Models.ContractAdapters;
using SkillJourney.Models.SkillRatings;
using SkillJourney.Models.Users;

namespace SkillJourney.Models.NotableHighlights;

public interface INotableHighlightsListModel
{
    IReadOnlyList<INotableHighlightModel> NotableHighlights { get; }

    Task<INotableHighlightModel> CreateNotableHighlightForUser(
        IUserModel receivingUser,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<ISkillRatingModel> relatedSkillRatings);
}
internal class NotableHighlightsListModel : INotableHighlightsListModel
{
    private readonly INotableHighlightsAdapter notableHighlightsAdapter;
    private readonly ICurrentUserModel currentUser;

    public NotableHighlightsListModel(
        INotableHighlightsAdapter notableHighlightsAdapter,
        ICurrentUserModel currentUser)
    {
        this.notableHighlightsAdapter = notableHighlightsAdapter;
        this.currentUser = currentUser;
        NotableHighlights = currentUser.CurrentUser.Highlights;
    }

    public IReadOnlyList<INotableHighlightModel> NotableHighlights { get; }

    public Task<INotableHighlightModel> CreateNotableHighlightForUser(
        IUserModel receivingUser,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<ISkillRatingModel> relatedSkillRatings)
        => notableHighlightsAdapter.CreateNotableHighlightForUser(
            receivingUser.Id,
            currentUser.CurrentUser.Id,
            significanceRating,
            description,
            dateOfOccurrence,
            relatedSkillRatings.Select(x => x.Id).ToList());
}
