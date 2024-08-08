namespace SkillJourney.Database.SkillCategories;
public interface ISkillCategoryEntry
{
    Guid Id { get; set; }
    string Name { get; set; }
}

internal class SkillCategoryEntry : ISkillCategoryEntry
{
    public SkillCategoryEntry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}