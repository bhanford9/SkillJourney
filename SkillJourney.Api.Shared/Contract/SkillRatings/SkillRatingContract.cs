using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Api.Shared.Contract.SkillFields;

namespace SkillJourney.Api.Shared.Contract.SkillRatings;

public record SkillRatingContract(
    Guid Id,
    string Name,
    string Description,
    BusinessAreaContract BusinessArea,
    SkillFieldContract SkillField,
    SkillCategoryContract SkillCategory,
    int Value,
    bool IsObsolete);
