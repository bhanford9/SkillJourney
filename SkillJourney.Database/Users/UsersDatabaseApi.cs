namespace SkillJourney.Database.Users;
public interface IUsersDatabaseApi
{
    IUserEntry GetUserById(Guid id);
    IReadOnlyList<IUserEntry> GetAllUsers();
    IUserEntry GetDevUser();
}

internal class UsersDatabaseApi : IUsersDatabaseApi
{
    private readonly IUsersDatabase database;

    public UsersDatabaseApi(IUsersDatabase database)
    {
        this.database = database;
    }

    public IUserEntry GetUserById(Guid id) => database.Users.First(x => x.Id == id);

    public IReadOnlyList<IUserEntry> GetAllUsers() => database.Users.ToList();

    public IUserEntry GetDevUser() => database.DevUser;
}
