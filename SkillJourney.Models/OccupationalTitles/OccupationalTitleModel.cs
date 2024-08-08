namespace SkillJourney.Models.OccupationalTitles;

public interface IOccupationalTitleModel
{
    Guid Id { get; }
    string Name { get; }
}

internal class OccupationalTitleModel : IOccupationalTitleModel
{
    public OccupationalTitleModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}
