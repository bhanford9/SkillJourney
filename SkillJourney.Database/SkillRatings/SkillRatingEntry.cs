namespace SkillJourney.Database.SkillRatings;

/// <summary>
/// In order to keep Skill Ratings mutable and have the application still work,
/// we can store them in the database and have the application adapt to them
/// 
/// Updating the Skill Ratings will only require a database migration and the 
/// application will continue to work as expected
/// </summary>
public interface ISkillRatingEntry
{
    string Description { get; }
    string Name { get; }
    int Value { get; }
    bool IsObsolete { get; }
    Guid Id { get; }
    Guid BusinessArea { get; }
    Guid SkillField { get; }
    Guid SkillCategory { get; }
}

internal class SkillRatingEntry(
    Guid id,
    string name,
    string description,
    Guid businessArea,
    Guid skillField,
    Guid skillCategory,
    int value,
    bool isObsolete) : ISkillRatingEntry
{
    public Guid Id { get; } = id;

    public string Name { get; } = name;

    public string Description { get; } = description;

    public Guid BusinessArea { get; } = businessArea;

    public Guid SkillField { get; } = skillField;

    public Guid SkillCategory { get; } = skillCategory;

    public int Value { get; } = value;

    public bool IsObsolete { get; } = isObsolete;
}
