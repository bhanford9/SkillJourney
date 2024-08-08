namespace SkillJourney.Models.SkillCategories;
internal interface ISkillCategoryFactory
{
    ISkillCategoryModel CreateSkillCategory(Guid id, string name);
}

internal class SkillCategoryFactory : ISkillCategoryFactory
{
    public ISkillCategoryModel CreateSkillCategory(Guid id, string name)
        => new SkillCategoryModel(id, name);
}
