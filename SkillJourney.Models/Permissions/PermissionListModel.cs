using SkillJourney.Models.ContractAdapters;
using static SkillJourney.Models.Permissions.PermissionEvents;

namespace SkillJourney.Models.Permissions;

public class PermissionEvents
{
    public delegate Task PermissionsChangedHandler();
}

public interface IPermissionListModel
{
    IReadOnlyList<IPermissionModel> Permissions { get; }

    Task<IReadOnlyList<IPermissionModel>> InitializePermissions();
    Task<IReadOnlyList<IPermissionModel>> SavePermissions();

    event PermissionsChangedHandler? PermissionsChanged;
}

internal class PermissionListModel : IPermissionListModel
{
    private readonly IPermissionsAdapter permissionsAdapter;

    public PermissionListModel(IPermissionsAdapter permissionsAdapter)
    {
        this.permissionsAdapter = permissionsAdapter;
    }

    public event PermissionsChangedHandler? PermissionsChanged;

    public IReadOnlyList<IPermissionModel> Permissions { get; private set; } = [];

    public async Task<IReadOnlyList<IPermissionModel>> InitializePermissions()
        => Permissions = await permissionsAdapter.GetAllPermissions();

    public async Task<IReadOnlyList<IPermissionModel>> SavePermissions()
    {
        var result = await permissionsAdapter.SavePermissions(Permissions);
        PermissionsChanged?.Invoke();
        return result;
    }
}
