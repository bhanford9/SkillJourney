using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings;

public interface ISkillRatingsDatabaseApi
{
    IReadOnlyList<ISkillRatingEntry> GetAllRatings();
    ISkillRatingEntry GetRatingById(Guid id);
    ISkillRatingEntry GetSkillRating(string businessArea, string field, string category, SkillRatingValue skillRatingValue);
}

internal class SkillRatingsDatabaseApi : ISkillRatingsDatabaseApi
{
    private readonly ISkillRatingsDatabase database;
    private readonly IBusinessAreasDatabaseApi businessAreasDatabaseApi;
    private readonly ISkillFieldsDatabaseApi skillFieldsDatabaseApi;
    private readonly ISkillCategoriesDatabaseApi skillCategoriesDatabaseApi;

    public SkillRatingsDatabaseApi(
        ISkillRatingsDatabase database,
        IBusinessAreasDatabaseApi businessAreasDatabaseApi,
        ISkillFieldsDatabaseApi skillFieldsDatabaseApi,
        ISkillCategoriesDatabaseApi skillCategoriesDatabaseApi)
    {
        this.database = database;
        this.businessAreasDatabaseApi = businessAreasDatabaseApi;
        this.skillFieldsDatabaseApi = skillFieldsDatabaseApi;
        this.skillCategoriesDatabaseApi = skillCategoriesDatabaseApi;
    }

    public ISkillRatingEntry GetSkillRating(string businessArea, string field, string category, SkillRatingValue skillRatingValue) =>
        database.SkillRatings.First(x =>
            x.BusinessArea == businessAreasDatabaseApi.GetIdByName(businessArea) &&
            x.SkillField == skillFieldsDatabaseApi.GetIdByName(field) &&
            x.SkillCategory == skillCategoriesDatabaseApi.GetIdByName(category) &&
            x.Value == skillRatingValue.Value());

    public IReadOnlyList<ISkillRatingEntry> GetAllRatings() => database.SkillRatings;

    public ISkillRatingEntry GetRatingById(Guid id) => database.SkillRatings.First(r => r.Id == id);
}
