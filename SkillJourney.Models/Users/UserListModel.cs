using SkillJourney.Models.ContractAdapters;

namespace SkillJourney.Models.Users;

public interface IUserListModel
{
    IReadOnlyList<IUserModel> Users { get; }

    Task<IReadOnlyList<IUserModel>> InitializeUsers();
}

internal class UserListModel : IUserListModel
{
    private readonly IUsersAdapter usersAdapter;

    public UserListModel(IUsersAdapter usersAdapter)
    {
        this.usersAdapter = usersAdapter;
    }

    public IReadOnlyList<IUserModel> Users { get; private set; } = [];

    public async Task<IReadOnlyList<IUserModel>> InitializeUsers()
        => Users = await usersAdapter.GetAllUsers();
}
