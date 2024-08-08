
namespace SkillJourney.Database.NotableHighlights;

public interface INotableHighlightEntry
{
    DateTime DateOfOccurrence { get; set; }
    string Description { get; set; }
    Guid Id { get; set; }
    int SignificanceRating { get; set; }
    Guid User { get; set; }
}

internal class NotableHighlightEntry : INotableHighlightEntry
{
    public NotableHighlightEntry(
        Guid id,
        Guid user,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
    {
        Id = id;
        User = user;
        SignificanceRating = significanceRating;
        Description = description;
        DateOfOccurrence = dateOfOccurrence;
    }

    public Guid Id { get; set; }

    public Guid User { get; set; }

    public int SignificanceRating { get; set; }

    public string Description { get; set; }

    public DateTime DateOfOccurrence { get; set; }
}
