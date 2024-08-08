namespace SkillJourney.Database.BusinessAreas;

public interface IBusinessAreasDatabaseApi
{
    IBusinessAreaEntry GetBusinessAreaById(Guid id);
    Guid GetIdByName(string name);
}

internal class BusinessAreasDatabaseApi : IBusinessAreasDatabaseApi
{
    private readonly IBusinessAreasDatabase database;

    public BusinessAreasDatabaseApi(IBusinessAreasDatabase database)
    {
        this.database = database;
    }

    public Guid GetIdByName(string name) => database.BusinessAreas.First(x => x.Name == name).Id;

    public IBusinessAreaEntry GetBusinessAreaById(Guid id) => database.BusinessAreas.First(x => x.Id == id);
}
