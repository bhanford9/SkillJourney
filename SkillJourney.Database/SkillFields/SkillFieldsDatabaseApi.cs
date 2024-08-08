namespace SkillJourney.Database.SkillFields;

public interface ISkillFieldsDatabaseApi
{
    ISkillFieldEntry GetSkillFieldById(Guid id);
    Guid GetIdByName(string name);
}

internal class SkillFieldsDatabaseApi : ISkillFieldsDatabaseApi
{
    private readonly ISkillFieldsDatabase database;

    public SkillFieldsDatabaseApi(ISkillFieldsDatabase database)
    {
        this.database = database;
    }

    public Guid GetIdByName(string name) => database.SkillFields.First(x => x.Name == name).Id;

    public ISkillFieldEntry GetSkillFieldById(Guid id) => database.SkillFields.First(x => x.Id == id);
}
