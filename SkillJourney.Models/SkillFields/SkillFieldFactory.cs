namespace SkillJourney.Models.SkillFields;
internal interface ISkillFieldFactory
{
    ISkillFieldModel CreateSkillField(Guid id, string name);
}

internal class SkillFieldFactory : ISkillFieldFactory
{
    public ISkillFieldModel CreateSkillField(Guid id, string name)
        => new SkillFieldModel(id, name);
}
