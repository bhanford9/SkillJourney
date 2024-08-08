using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface INotableHighlightRelatedSkillContractBuilder
{
    NotableHighlightRelatedSkillContract BuildContract(INotableHighlightRelatedSkillEntry relation, SkillRatingContract skillRating);
}

public class NotableHighlightRelatedSkillContractBuilder : INotableHighlightRelatedSkillContractBuilder
{
    public NotableHighlightRelatedSkillContract BuildContract(
        INotableHighlightRelatedSkillEntry relation,
        SkillRatingContract skillRating)
        => new(relation.Id, skillRating);
}
