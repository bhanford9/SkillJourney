using SkillJourney.Models.Permissions;
using SkillJourney.ViewModels.Utilities;
using System.Collections.ObjectModel;

namespace SkillJourney.ViewModels.DeveloperTools;
public interface IPermissionsListViewModel : IViewModel
{
    ObservableCollection<IPermissionsListItemViewModel> Permissions { get; }

    Task SavePermissions();
}

internal partial class PermissionsListViewModel : ViewModel, IPermissionsListViewModel
{
    private readonly IPermissionListModel permissionsList;
    private readonly IViewModelFactory viewModelFactory;
    private readonly IPermissionFactory permissionFactory;

    public PermissionsListViewModel(
        IPermissionListModel permissionsList,
        IViewModelFactory viewModelFactory,
        IPermissionFactory permissionFactory)
    {
        this.permissionsList = permissionsList;
        this.viewModelFactory = viewModelFactory;
        this.permissionFactory = permissionFactory;
    }

    public ObservableCollection<IPermissionsListItemViewModel> Permissions { get; } = [];

    public override async Task OnInitializedAsync()
        => Permissions.ClearAndAddRange((await permissionsList.InitializePermissions()).Select(viewModelFactory.BuildPermissionsListItem));

    public async Task SavePermissions()
    {
        foreach (var permission in Permissions)
            permissionsList.Permissions.First(x => x.Id == permission.Permission.Id).IsDeprecated = permission.Permission.IsDeprecated;
        Permissions.ClearAndAddRange((await permissionsList.SavePermissions()).Select(viewModelFactory.BuildPermissionsListItem));
    }
}
