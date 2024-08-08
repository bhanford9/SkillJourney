using SkillJourney.Models.SkillRatings;

namespace SkillJourney.Models.NotableHighlights;

public interface INotableHighlightModel
{
    DateTime DateOfOccurrence { get; }
    string Description { get; }
    Guid Id { get; }
    int SignificanceRating { get; }
    IReadOnlyList<ISkillRatingModel> RelatedSkillRatings { get; }
}

internal class NotableHighlightModel : INotableHighlightModel
{
    public NotableHighlightModel(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<ISkillRatingModel> relatedSkillRatings)
    {
        Id = id;
        SignificanceRating = significanceRating;
        Description = description;
        DateOfOccurrence = dateOfOccurrence;
        RelatedSkillRatings = relatedSkillRatings;
    }

    public Guid Id { get; }

    public int SignificanceRating { get; }

    public string Description { get; } = string.Empty;

    public DateTime DateOfOccurrence { get; }

    public IReadOnlyList<ISkillRatingModel> RelatedSkillRatings { get; }
}
