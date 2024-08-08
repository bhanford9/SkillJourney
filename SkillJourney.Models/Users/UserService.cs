using SkillJourney.Models.ContractAdapters;

namespace SkillJourney.Models.Users;

public interface IUserService
{
    Task<IUserModel> GetExistingUser(Guid id);
}

internal class UserService : IUserService
{
    private readonly IUsersAdapter usersAdapter;

    public UserService(IUsersAdapter usersAdapter)
    {
        this.usersAdapter = usersAdapter;
    }

    public Task<IUserModel> GetExistingUser(Guid id) => usersAdapter.GetUser(id);
}
