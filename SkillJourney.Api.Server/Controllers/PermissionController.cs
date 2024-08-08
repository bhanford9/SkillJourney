using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.Database.Permissions;

namespace SkillJourney.Api.Server.Controllers;

public interface IPermissionController
{
    IReadOnlyList<PermissionContract> GetAllPermissions();
    PermissionContract GetDevUserPermission();
    IReadOnlyList<PermissionContract> GetPermissions(Guid userId, Guid titleId);
    PermissionContract GetViewUserHighlightsPermission();
    IReadOnlyList<PermissionContract> UpdatePermissions(IReadOnlyList<PermissionContract> permissions);
}

public class PermissionController : IPermissionController
{
    private readonly IPermissionsDatabaseApi permissionsDatabaseApi;
    private readonly IPermissionContractBuilder permissionContractBuilder;

    public PermissionController(
        IPermissionsDatabaseApi permissionsDatabaseApi,
        IPermissionContractBuilder permissionContractBuilder)
    {
        this.permissionsDatabaseApi = permissionsDatabaseApi;
        this.permissionContractBuilder = permissionContractBuilder;
    }

    public IReadOnlyList<PermissionContract> GetAllPermissions() => permissionsDatabaseApi
        .GetAllPermissions()
        .Select(permissionContractBuilder.BuildContract)
        .ToList();

    public IReadOnlyList<PermissionContract> GetPermissions(Guid userId, Guid titleId) => permissionsDatabaseApi
        .GetPermissions(userId, titleId)
        .Select(permissionContractBuilder.BuildContract)
        .ToList();

    public PermissionContract GetDevUserPermission()
        => permissionContractBuilder.BuildContract(permissionsDatabaseApi.GetDevPermission());

    public PermissionContract GetViewUserHighlightsPermission()
        => permissionContractBuilder.BuildContract(permissionsDatabaseApi.GetViewUserHighlightsPermission());

    public IReadOnlyList<PermissionContract> UpdatePermissions(IReadOnlyList<PermissionContract> permissions) => permissionsDatabaseApi
        .UpdatePermissions(permissions.Select(x => (x.Id, x.IsDeprecated)))
        .Select(permissionContractBuilder.BuildContract)
        .ToList();

}
