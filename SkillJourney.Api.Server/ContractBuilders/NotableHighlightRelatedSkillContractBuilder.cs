using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface INotableHighlightRelatedSkillContractBuilder
{
    NotableHighlightRelatedSkillContract BuildContract(NotableHighlightRelatedSkillSubContract relation, SkillRatingContract skillRating);
    NotableHighlightRelatedSkillSubContract BuildSubContract(INotableHighlightRelatedSkillEntry notableHighlightRelatedSkillEntry);
}

public class NotableHighlightRelatedSkillContractBuilder : INotableHighlightRelatedSkillContractBuilder
{
    private readonly ISkillRatingController skillRatingsController;
    private readonly ISkillRatingContractBuilder skillRatingContractBuilder;

    public NotableHighlightRelatedSkillContractBuilder(
        ISkillRatingController skillRatingsController,
        ISkillRatingContractBuilder skillRatingContractBuilder)
    {
        this.skillRatingsController = skillRatingsController;
        this.skillRatingContractBuilder = skillRatingContractBuilder;
    }
    public NotableHighlightRelatedSkillSubContract BuildSubContract(
        INotableHighlightRelatedSkillEntry notableHighlightRelatedSkillEntry)
    => new(
        notableHighlightRelatedSkillEntry.Id,
        notableHighlightRelatedSkillEntry.RelatedSkill);

    public NotableHighlightRelatedSkillContract BuildContract(
        NotableHighlightRelatedSkillSubContract relation,
        SkillRatingContract skillRating)
        => new(relation.Id, skillRating);
}
