namespace SkillJourney.Database.NotableHighlights;
public interface INotableHighlightsDatabaseApi
{
    IReadOnlyList<INotableHighlightEntry> GetHighlightsForUser(Guid user);
    INotableHighlightEntry GetHighlightById(Guid id);
    INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkills);
    void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence);
    IReadOnlyList<INotableHighlightRelatedSkillEntry> GetHighlightRelatedSkills(Guid highlight);
}

internal class NotableHighlightsDatabaseApi : INotableHighlightsDatabaseApi
{
    private readonly INotableHighlightsDatabase notableHighlightsDatabase;
    private readonly INotableHighlightRelatedSkillsDatabase notableHighlightRelatedSkillsDatabase;

    public NotableHighlightsDatabaseApi(
        INotableHighlightsDatabase database,
        INotableHighlightRelatedSkillsDatabase notableHighlightRelatedSkillsDatabase)
    {
        this.notableHighlightsDatabase = database;
        this.notableHighlightRelatedSkillsDatabase = notableHighlightRelatedSkillsDatabase;
    }

    public INotableHighlightEntry GetHighlightById(Guid id)
        => notableHighlightsDatabase.NotableHighlights.First(x => x.Id == id);

    public IReadOnlyList<INotableHighlightEntry> GetHighlightsForUser(Guid user)
        => notableHighlightsDatabase.NotableHighlights.Where(x => x.User == user).ToList();

    public IReadOnlyList<INotableHighlightRelatedSkillEntry> GetHighlightRelatedSkills(Guid highlight)
        => notableHighlightRelatedSkillsDatabase.NotableHighlightRelatedSkills
        .Where(x => x.NotableHighlight == highlight)
        .ToList();

    public INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<Guid> relatedSkills)
    {
        var highlight = notableHighlightsDatabase.AddHighlight(
            userId,
            significanceRating,
            description,
            dateOfOccurrence);
        notableHighlightRelatedSkillsDatabase.AddRelatedSkills(highlight.Id, relatedSkills.ToArray());
        return highlight;
    }

    public void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
        => notableHighlightsDatabase.UpdateHighlight(
            id,
            significanceRating,
            description,
            dateOfOccurrence);
}
