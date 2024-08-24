using SkillJourney.Database.Users;

namespace SkillJourney.Database.NotableHighlights;
public interface INotableHighlightsDatabase
{
    IReadOnlyList<INotableHighlightEntry> NotableHighlights { get; }

    INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence);
    void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence);
}

internal class NotableHighlightsDatabase : INotableHighlightsDatabase
{
    private readonly List<INotableHighlightEntry> notableHighlights = [];
    

    public NotableHighlightsDatabase(IUsersDatabaseApi usersDatabaseApi)
    {
        notableHighlights.Add(new NotableHighlightEntry(
            new("3f7e5a2b-9772-4ce4-8856-9c019a430b58"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "learned new unit test framework",
            new DateTime(2022, 3, 19)));
    }

    public IReadOnlyList<INotableHighlightEntry> NotableHighlights => notableHighlights;

    public INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
    {
        var entry = new NotableHighlightEntry(
            Guid.NewGuid(),
            userId,
            significanceRating,
            description,
            dateOfOccurrence);
        notableHighlights.Add(entry);
        return entry;
    }

    public void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
    {
        var highlight = notableHighlights[notableHighlights.IndexOf(notableHighlights.First(x => x.Id.Equals(id)))];

        highlight.SignificanceRating = significanceRating;
        highlight.Description = description;
        highlight.DateOfOccurrence = dateOfOccurrence;
    }
}
