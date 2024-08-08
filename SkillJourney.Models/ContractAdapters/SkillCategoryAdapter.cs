using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Models.SkillCategories;

namespace SkillJourney.Models.ContractAdapters;
public interface ISkillCategoriesAdapter
{
    ISkillCategoryModel ToModel(SkillCategoryContract skillCategory);
}

internal class SkillCategoriesAdapter : ISkillCategoriesAdapter
{
    private readonly ISkillCategoryFactory skillCategoryFactory;

    public SkillCategoriesAdapter(ISkillCategoryFactory skillCategoryFactory)
    {
        this.skillCategoryFactory = skillCategoryFactory;
    }

    public ISkillCategoryModel ToModel(SkillCategoryContract skillCategory)
        => skillCategoryFactory.CreateSkillCategory(skillCategory.Id, skillCategory.Name);
}