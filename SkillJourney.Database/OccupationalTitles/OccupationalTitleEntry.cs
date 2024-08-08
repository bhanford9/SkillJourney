namespace SkillJourney.Database.OccupationalTitles;
public interface IOccupationalTitleEntry
{
    Guid Id { get; set; }
    string Name { get; set; }
}

internal class OccupationalTitleEntry : IOccupationalTitleEntry
{
    public OccupationalTitleEntry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
