using SkillJourney.Models.BusinessAreas;
using SkillJourney.Models.SkillCategories;
using SkillJourney.Models.SkillFields;

namespace SkillJourney.Models.SkillRatings;

public interface ISkillRatingModel
{
    public Guid Id { get; }
    string Description { get; }
    IBusinessAreaModel BusinessArea { get; }
    ISkillFieldModel SkillField { get; }
    ISkillCategoryModel SkillCategory { get; }
    string Name { get; }
    SkillRatingValue Value { get; }
    bool IsObsolete { get; }
}

internal class SkillRatingModel : ISkillRatingModel
{
    public SkillRatingModel(
        Guid id,
        string name,
        string description,
        IBusinessAreaModel businessArea,
        ISkillFieldModel skillField,
        ISkillCategoryModel skillCategory,
        bool isObsolete,
        SkillRatingValue value)
    {
        Id = id;
        Name = name;
        Description = description;
        BusinessArea = businessArea;
        SkillField = skillField;
        SkillCategory = skillCategory;
        Value = value;
        IsObsolete = isObsolete;
    }

    public Guid Id { get; }

    public string Name { get; } = string.Empty;

    public string Description { get; } = string.Empty;

    public IBusinessAreaModel BusinessArea { get; }

    public ISkillFieldModel SkillField { get; }

    public ISkillCategoryModel SkillCategory { get; }

    public SkillRatingValue Value { get; } = SkillRatingValue.Beginner;

    public bool IsObsolete { get; }
}
