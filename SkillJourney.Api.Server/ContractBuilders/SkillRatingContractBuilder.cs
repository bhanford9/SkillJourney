using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Api.Shared.Contract.SkillFields;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.SkillRatings;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface ISkillRatingContractBuilder
{
    SkillRatingContract BuildContract(
        SkillRatingSubContract skillRating,
        BusinessAreaContract businessArea,
        SkillFieldContract skillField,
        SkillCategoryContract skillCategory);
    SkillRatingSubContract BuildSubContract(ISkillRatingEntry rating);
}

public class SkillRatingContractBuilder : ISkillRatingContractBuilder
{
    public SkillRatingSubContract BuildSubContract(ISkillRatingEntry rating)
    => new(
        rating.Id,
        rating.Name,
        rating.Description,
        rating.BusinessArea,
        rating.SkillField,
        rating.SkillCategory,
        rating.Value,
        rating.IsObsolete);

    public SkillRatingContract BuildContract(
        SkillRatingSubContract skillRating,
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
