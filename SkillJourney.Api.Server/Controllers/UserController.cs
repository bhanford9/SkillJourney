using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.Users;
using SkillJourney.Database.Users;

namespace SkillJourney.Api.Server.Controllers;

public interface IUserController
{
    IReadOnlyList<UserContract> GetAllUsers();
    UserContract GetDevUser();
    UserContract GetUserById(Guid id);
}

public class UserController : IUserController
{
    private readonly IUsersDatabaseApi usersDatabaseApi;
    private readonly IUserContractBuilder userContractBuilder;
    private readonly IOccupationalTitleController occupationalTitleController;
    private readonly INotableHighlightController notableHighlightController;
    private readonly IPermissionController permissionController;

    public UserController(
        IUsersDatabaseApi usersDatabaseApi,
        IUserContractBuilder userContractBuilder,
        IOccupationalTitleController occupationalTitleController,
        INotableHighlightController notableHighlightController,
        IPermissionController permissionController)
    {
        this.usersDatabaseApi = usersDatabaseApi;
        this.userContractBuilder = userContractBuilder;
        this.occupationalTitleController = occupationalTitleController;
        this.notableHighlightController = notableHighlightController;
        this.permissionController = permissionController;
    }

    public IReadOnlyList<UserContract> GetAllUsers()
        => usersDatabaseApi.GetAllUsers().Select(BuildContract).ToList();

    public UserContract GetUserById(Guid id) => BuildContract(usersDatabaseApi.GetUserById(id));

    public UserContract GetDevUser() => BuildContract(usersDatabaseApi.GetDevUser());

    private UserContract BuildContract(IUserEntry entry)
        => userContractBuilder.BuildContract(
            entry,
            occupationalTitleController.FromId(entry.OccupationalTitle),
            notableHighlightController.GetUserHighlights(entry.Id),
            permissionController.GetPermissions(entry.Id, entry.OccupationalTitle));
}