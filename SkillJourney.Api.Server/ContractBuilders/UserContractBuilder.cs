using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.Api.Shared.Contract.Users;
using SkillJourney.Database.Users;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface IUserContractBuilder
{
    UserContract BuildContract(
        UserSubContract user,
        OccupationalTitleContract occupationalTitle,
        IReadOnlyList<NotableHighlightContract> highlights,
        IReadOnlyList<PermissionContract> permissions);
    UserSubContract BuildSubContract(IUserEntry user);
}

public class UserContractBuilder : IUserContractBuilder
{
    private readonly INotableHighlightController notableHighlighController;
    private readonly IPermissionController permissionController;

    public UserContractBuilder(
        INotableHighlightController notableHighlighController,
        IPermissionController permissionController)
    {
        this.notableHighlighController = notableHighlighController;
        this.permissionController = permissionController;
    }

    public UserSubContract BuildSubContract(IUserEntry user) => new(
        user.Id,
        user.Name,
        user.OccupationalTitle);

    public UserContract BuildContract(
        UserSubContract user,
        OccupationalTitleContract occupationalTitle,
        IReadOnlyList<NotableHighlightContract> highlights,
        IReadOnlyList<PermissionContract> permissions) => new(
            user.Id,
            user.Name,
            occupationalTitle,
            highlights,
            permissions);
}
