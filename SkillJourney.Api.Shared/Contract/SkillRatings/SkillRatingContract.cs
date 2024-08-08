using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Api.Shared.Contract.SkillFields;

namespace SkillJourney.Api.Shared.Contract.SkillRatings;

public record SkillRatingSubContract(
    Guid Id,
    string Name,
    string Description,
    Guid BusinessArea,
    Guid SkillField,
    Guid SkillCategory,
    int Value,
    bool IsObsolete);

public record SkillRatingContract(
    Guid Id,
    string Name,
    string Description,
    BusinessAreaContract BusinessArea,
    SkillFieldContract SkillField,
    SkillCategoryContract SkillCategory,
    int Value,
    bool IsObsolete);
