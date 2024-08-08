namespace SkillJourney.Database.NotableHighlights;

internal interface INotableHighlightRelatedSkillsDatabase
{
    IReadOnlyList<INotableHighlightRelatedSkillEntry> NotableHighlightRelatedSkills { get; }

    void AddRelatedSkills(Guid notableHighlight, params Guid[] relatedSkills);
}

internal class NotableHighlightRelatedSkillsDatabase : INotableHighlightRelatedSkillsDatabase
{
    private readonly List<INotableHighlightRelatedSkillEntry> notableHighlightRelatedSkills = [];

    public IReadOnlyList<INotableHighlightRelatedSkillEntry> NotableHighlightRelatedSkills => notableHighlightRelatedSkills;

    public void AddRelatedSkills(Guid notableHighlight, params Guid[] relatedSkills)
    {
        notableHighlightRelatedSkills.AddRange(relatedSkills.Select(x => 
            new NotableHighlightRelatedSkillEntry
            {
                Id = Guid.NewGuid(),
                NotableHighlight = notableHighlight,
                RelatedSkill = x
            }));
    }
}
