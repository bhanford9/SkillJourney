namespace SkillJourney.Database.OccupationalTitles;
public interface IOccupationalTitlesDatabaseApi
{
    IOccupationalTitleEntry GetOccupationalTitleById(Guid id);
    IReadOnlyList<IOccupationalTitleEntry> GetAllOccupationalTitles();
}

internal class OccupationalTitlesDatabaseApi : IOccupationalTitlesDatabaseApi
{
    private readonly IOccupationalTitlesDatabase database;

    public OccupationalTitlesDatabaseApi(IOccupationalTitlesDatabase database)
    {
        this.database = database;
    }

    public IOccupationalTitleEntry GetOccupationalTitleById(Guid id)
        => database.OccupationalTitles.First(x => x.Id == id);

    public IReadOnlyList<IOccupationalTitleEntry> GetAllOccupationalTitles()
        => database.OccupationalTitles.ToList();
}