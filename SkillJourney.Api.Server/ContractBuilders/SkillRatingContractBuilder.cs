using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Api.Shared.Contract.SkillFields;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.SkillRatings;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface ISkillRatingContractBuilder
{
    SkillRatingContract BuildContract(
        ISkillRatingEntry skillRating,
        BusinessAreaContract businessArea,
        SkillFieldContract skillField,
        SkillCategoryContract skillCategory);
}

public class SkillRatingContractBuilder : ISkillRatingContractBuilder
{
    public SkillRatingContract BuildContract(
        ISkillRatingEntry skillRating,
        BusinessAreaContract businessArea,
        SkillFieldContract skillField,
        SkillCategoryContract skillCategory) => new(
            skillRating.Id,
            skillRating.Name,
            skillRating.Description,
            businessArea,
            skillField,
            skillCategory,
            skillRating.Value,
            skillRating.IsObsolete);
}
