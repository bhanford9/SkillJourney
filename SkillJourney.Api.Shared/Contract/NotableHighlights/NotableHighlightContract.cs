namespace SkillJourney.Api.Shared.Contract.NotableHighlights;

public record NotableHighlightContract(
    Guid Id,
    IReadOnlyList<NotableHighlightRelatedSkillContract> RelatedSkills,
    int SignificanceRating,
    string Description,
    DateTime DateOfOccurrence);
