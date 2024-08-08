using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.Models.Permissions;

namespace SkillJourney.Models.ContractAdapters;
public interface IPermissionsAdapter
{
    Task<IReadOnlyList<IPermissionModel>> GetAllPermissions();
    Task<IReadOnlyList<IPermissionModel>> SavePermissions(IReadOnlyList<IPermissionModel> permissions);
    IPermissionModel ToModel(PermissionContract permission);
}

internal class PermissionsAdapter : IPermissionsAdapter
{
    private readonly IPermissionFactory permissionFactory;
    private readonly IPermissionsClient permissionsClient;

    public PermissionsAdapter(IPermissionFactory permissionFactory, IPermissionsClient permissionsClient)
    {
        this.permissionFactory = permissionFactory;
        this.permissionsClient = permissionsClient;
    }

    public async Task<IReadOnlyList<IPermissionModel>> GetAllPermissions()
        => (await permissionsClient.GetAllPermissions()).Select(ToModel).ToList();

    public IPermissionModel ToModel(PermissionContract permission)
        => permissionFactory.CreatePermission(permission.Id, permission.Name, permission.IsDeprecated);

    public PermissionContract ToContract(IPermissionModel permission)
        => new PermissionContract(permission.Id, permission.Name, permission.IsDeprecated);

    public async Task<IReadOnlyList<IPermissionModel>> SavePermissions(IReadOnlyList<IPermissionModel> permissions)
        => (await permissionsClient.SavePermissions(permissions.Select(ToContract).ToList())).Select(ToModel).ToList();
}
