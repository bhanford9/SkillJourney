namespace SkillJourney.Models.OccupationalTitles;

public interface IOccupationalTitleFactory
{
    IOccupationalTitleModel CreateOccupationalTitle(Guid id, string name);
}

internal class OccupationalTitleFactory : IOccupationalTitleFactory
{
    public IOccupationalTitleModel CreateOccupationalTitle(Guid id, string name)
        => new OccupationalTitleModel(id, name);
}
