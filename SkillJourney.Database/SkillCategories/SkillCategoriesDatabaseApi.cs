namespace SkillJourney.Database.SkillCategories;

public interface ISkillCategoriesDatabaseApi
{
    ISkillCategoryEntry GetSkillCategoryById(Guid id);
    Guid GetIdByName(string name);
}

internal class SkillCategoriesDatabaseApi : ISkillCategoriesDatabaseApi
{
    private readonly ISkillCategoriesDatabase database;

    public SkillCategoriesDatabaseApi(ISkillCategoriesDatabase database)
    {
        this.database = database;
    }

    public Guid GetIdByName(string name) => database.SkillCategories.First(x => x.Name == name).Id;

    public ISkillCategoryEntry GetSkillCategoryById(Guid id) => database.SkillCategories.First(x => x.Id == id);
}
