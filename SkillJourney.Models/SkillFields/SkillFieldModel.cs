namespace SkillJourney.Models.SkillFields;
public interface ISkillFieldModel
{
    Guid Id { get; }
    string Name { get; }
}

internal class SkillFieldModel : ISkillFieldModel
{
    public SkillFieldModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}
