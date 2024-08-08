namespace SkillJourney.Api.Shared.Contract.NotableHighlights;
public record AddNotableHighlightContract(
    Guid ReceivingUser,
    Guid ActingUser,
    int SignificanceRating,
    string Description,
    DateTime DateOfOccurrence,
    IReadOnlyList<Guid> RelatedSkillRatings);
