namespace SkillJourney.Database.SkillFields;
public interface ISkillFieldEntry
{
    Guid Id { get; set; }
    string Name { get; set; }
}

internal class SkillFieldEntry : ISkillFieldEntry
{
    public SkillFieldEntry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}