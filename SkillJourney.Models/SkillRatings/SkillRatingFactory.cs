using SkillJourney.Models.BusinessAreas;
using SkillJourney.Models.SkillCategories;
using SkillJourney.Models.SkillFields;

namespace SkillJourney.Models.SkillRatings;

internal interface ISkillRatingFactory
{
    ISkillRatingModel BuildSkillRating(
        Guid id,
        string name,
        string description,
        IBusinessAreaModel businessArea,
        ISkillFieldModel skillField,
        ISkillCategoryModel skillCategory,
        bool isObsolete,
        SkillRatingValue value);
}

internal class SkillRatingFactory : ISkillRatingFactory
{
    public ISkillRatingModel BuildSkillRating(
        Guid id,
        string name,
        string description,
        IBusinessAreaModel businessArea,
        ISkillFieldModel skillField,
        ISkillCategoryModel skillCategory,
        bool isObsolete,
        SkillRatingValue value)
        => new SkillRatingModel(id, name, description, businessArea, skillField, skillCategory, isObsolete, value);
}
