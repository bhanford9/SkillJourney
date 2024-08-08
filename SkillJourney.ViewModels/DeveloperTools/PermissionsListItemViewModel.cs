using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.ViewModels.Permissions;

namespace SkillJourney.ViewModels.DeveloperTools;

public interface IPermissionsListItemViewModel : IViewModel
{
    IPermissionViewModel Permission { get; set; }
}

internal partial class PermissionsListItemViewModel : ViewModel, IPermissionsListItemViewModel
{
    [ObservableProperty] private IPermissionViewModel permission;

    public PermissionsListItemViewModel(IPermissionViewModel permissionViewModel)
    {
        this.permission = permissionViewModel;
    }
}
