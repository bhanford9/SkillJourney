namespace SkillJourney.Models.SkillCategories;
public interface ISkillCategoryModel
{
    Guid Id { get; }
    string Name { get; }
}

internal class SkillCategoryModel : ISkillCategoryModel
{
    public SkillCategoryModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}