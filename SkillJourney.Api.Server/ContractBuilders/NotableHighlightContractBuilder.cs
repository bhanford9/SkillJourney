using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface INotableHighlightContractBuilder
{
    NotableHighlightContract BuildContract(
        NotableHighlightSubContract highlight,
        IReadOnlyList<NotableHighlightRelatedSkillContract> relatedSkills);
    NotableHighlightSubContract BuildSubContract(INotableHighlightEntry highlight);
}

public class NotableHighlightContractBuilder : INotableHighlightContractBuilder
{
    public NotableHighlightSubContract BuildSubContract(INotableHighlightEntry highlight)
        => new(
            highlight.Id,
            highlight.SignificanceRating,
            highlight.Description,
            highlight.DateOfOccurrence);

    public NotableHighlightContract BuildContract(
        NotableHighlightSubContract highlight,
        IReadOnlyList<NotableHighlightRelatedSkillContract> relatedSkills) => new(
            highlight.Id,
            relatedSkills,
            highlight.SignificanceRating,
            highlight.Description,
            highlight.DateOfOccurrence);
}
