using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface INotableHighlightContractBuilder
{
    NotableHighlightContract BuildContract(
        INotableHighlightEntry highlight,
        IReadOnlyList<NotableHighlightRelatedSkillContract> relatedSkills);
}

public class NotableHighlightContractBuilder : INotableHighlightContractBuilder
{
    public NotableHighlightContract BuildContract(
        INotableHighlightEntry highlight,
        IReadOnlyList<NotableHighlightRelatedSkillContract> relatedSkills) => new(
            highlight.Id,
            relatedSkills,
            highlight.SignificanceRating,
            highlight.Description,
            highlight.DateOfOccurrence);
}
