using SkillJourney.Models.ContractAdapters;

namespace SkillJourney.Models.Users;

public interface ICurrentUserModel
{
    IUserModel CurrentUser { get; }

    Task DebugLogin();
}

internal class CurrentUserModel : ICurrentUserModel
{
    private readonly IUsersAdapter usersAdapter;

    public CurrentUserModel(IUsersAdapter usersAdapter)
    {
        this.usersAdapter = usersAdapter;
    }

    public IUserModel CurrentUser { get; private set; }

    public async Task DebugLogin() => CurrentUser = await usersAdapter.DebugLogin();
}
