namespace SkillJourney.Database.NotableHighlights;

public interface INotableHighlightRelatedSkillEntry
{
    Guid Id { get; set; }
    Guid NotableHighlight { get; set; }
    Guid RelatedSkill { get; set; }
}

internal class NotableHighlightRelatedSkillEntry : INotableHighlightRelatedSkillEntry
{
    public Guid Id { get; set; }
    public Guid NotableHighlight { get; set; }
    public Guid RelatedSkill { get; set; }
}
