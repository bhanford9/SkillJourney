using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.Users;
using SkillJourney.Models.Users;

namespace SkillJourney.Models.ContractAdapters;
public interface IUsersAdapter
{
    Task<IUserModel> DebugLogin();
    Task<IReadOnlyList<IUserModel>> GetAllUsers();
    Task<IUserModel> GetUser(Guid id);
    IUserModel ToModel(UserContract businessArea);
}

internal class UsersAdapter : IUsersAdapter
{
    private readonly IUserFactory usersFactory;
    private readonly IUsersClient usersClient;
    private readonly IOccupationalTitlesAdapter occupationalTitlesAdapter;
    private readonly IPermissionsAdapter permissionsAdapter;
    private readonly INotableHighlightsAdapter notableHighlightsAdapter;

    public UsersAdapter(
        IUserFactory usersFactory,
        IUsersClient usersClient,
        IOccupationalTitlesAdapter occupationalTitlesAdapter,
        IPermissionsAdapter permissionsAdapter,
        INotableHighlightsAdapter notableHighlightsAdapter)
    {
        this.usersFactory = usersFactory;
        this.usersClient = usersClient;
        this.occupationalTitlesAdapter = occupationalTitlesAdapter;
        this.permissionsAdapter = permissionsAdapter;
        this.notableHighlightsAdapter = notableHighlightsAdapter;
    }

    public async Task<IUserModel> DebugLogin() => ToModel(await usersClient.GetDevUser());

    public async Task<IReadOnlyList<IUserModel>> GetAllUsers() => (await usersClient.GetAllUsers()).Select(ToModel).ToList();

    public async Task<IUserModel> GetUser(Guid id) => ToModel(await usersClient.GetUserById(id));

    public IUserModel ToModel(UserContract user)
        => usersFactory.CreateUser(
            user.Id,
            user.Name,
            occupationalTitlesAdapter.ToModel(user.OccupationalTitle),
            user.Permissions.Select(permissionsAdapter.ToModel).ToList(),
            user.Highlights.Select(notableHighlightsAdapter.ToModel).ToList());
}
