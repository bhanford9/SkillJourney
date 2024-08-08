using SkillJourney.Database.OccupationalTitles;

namespace SkillJourney.Database.Users;
public interface IUsersDatabase
{
    IReadOnlyList<IUserEntry> Users { get; }
    IUserEntry DevUser { get; }
    IUserEntry EntrySoftwareEngineer { get; }
    IUserEntry SeniorSoftwareEngineer { get; }
    IUserEntry SoftwareManager { get; }
}

internal class UsersDatabase : IUsersDatabase
{
    private readonly IOccupationalTitlesDatabase occupationalTitlesDatabase;

    public UsersDatabase(IOccupationalTitlesDatabase occupationalTitlesDatabase)
    {
        this.occupationalTitlesDatabase = occupationalTitlesDatabase;

        DevUser = new UserEntry(
            new Guid("c0a0abd4-7c13-48d1-9ae3-057d5bea1287"),
            "Dev User",
            occupationalTitlesDatabase.SkillJourneyDeveloper.Id);

        EntrySoftwareEngineer = new UserEntry(
            new Guid("b4a8f1ec-8828-45de-9b99-e1d9e39e05c2"),
            "Junior Dev",
            occupationalTitlesDatabase.SoftwareEngineer1.Id);

        SeniorSoftwareEngineer = new UserEntry(
            new Guid("63d81e06-d037-4f56-b9ef-6b93ef3bc40d"),
            "Experienced Dev",
            occupationalTitlesDatabase.SeniorSoftwareEngineer.Id);

        SoftwareManager = new UserEntry(
            new Guid("a1b45c3d-93f4-49a1-8f8e-1e2f6cd9e1b8"),
            "Manager Mike",
            occupationalTitlesDatabase.EngagementManager.Id);
    }

    public IReadOnlyList<IUserEntry> Users => [
        DevUser,
        EntrySoftwareEngineer,
        SeniorSoftwareEngineer,
        SoftwareManager,
    ];

    public IUserEntry DevUser { get; }

    public IUserEntry EntrySoftwareEngineer { get; }

    public IUserEntry SeniorSoftwareEngineer { get; }

    public IUserEntry SoftwareManager { get; }
}
