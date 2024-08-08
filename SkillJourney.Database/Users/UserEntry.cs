namespace SkillJourney.Database.Users;
public interface IUserEntry
{
    Guid Id { get; set; }
    Guid OccupationalTitle { get; set; }
    string Name { get; set; }
}

internal class UserEntry : IUserEntry
{
    public UserEntry(Guid id, string name, Guid occupationalTitle)
    {
        Id = id;
        Name = name;
        OccupationalTitle = occupationalTitle;
    }

    public Guid Id { get; set; }
    public Guid OccupationalTitle { get; set; }
    public string Name { get; set; } = string.Empty;
}
