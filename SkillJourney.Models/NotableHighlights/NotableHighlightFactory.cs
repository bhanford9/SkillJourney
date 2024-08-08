using SkillJourney.Models.SkillRatings;

namespace SkillJourney.Models.NotableHighlights;

public interface INotableHighlightFactory
{
    public INotableHighlightModel CreateNotableHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<ISkillRatingModel> relatedSkillRatings);
}

internal class NotableHighlightFactory : INotableHighlightFactory
{
    public INotableHighlightModel CreateNotableHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence,
        IReadOnlyList<ISkillRatingModel> relatedSkillRatings)
        => new NotableHighlightModel(
            id,
            significanceRating,
            description,
            dateOfOccurrence,
            relatedSkillRatings);
}

