namespace SkillJourney.Database.SkillRatings;

public interface ISkillRatingsDatabase
{
    IReadOnlyList<ISkillRatingEntry> SkillRatings { get; }
}

internal class SkillRatingsDatabase : ISkillRatingsDatabase
{
    public SkillRatingsDatabase(IEnumerable<ISkillRatings> skillRatings)
        => this.SkillRatings = skillRatings.SelectMany(x => x.Skills).ToList();

    public IReadOnlyList<ISkillRatingEntry> SkillRatings { get; }
}
