namespace SkillJourney.Database.SkillRatings;

public interface ISkillRatingsDatabaseApi
{
    IReadOnlyList<ISkillRatingEntry> GetAllRatings();
    ISkillRatingEntry GetRatingById(Guid id);
}

internal class SkillRatingsDatabaseApi : ISkillRatingsDatabaseApi
{
    private readonly ISkillRatingsDatabase database;
    public SkillRatingsDatabaseApi(ISkillRatingsDatabase database)
    {
        this.database = database;
    }

    public IReadOnlyList<ISkillRatingEntry> GetAllRatings() => database.SkillRatings;

    public ISkillRatingEntry GetRatingById(Guid id) => database.SkillRatings.First(r => r.Id == id);
}
