using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.Permissions;
using SkillJourney.Models.Users;
using SkillJourney.PermissionsEngine;

namespace SkillJourney.ViewModels;

public interface IHeaderSideBarViewModel : IViewModel
{
    public bool DrawerOpen { get; set; }
    public bool CanAccessDevTools { get; set; }
    void DrawerToggle();
}

internal partial class HeaderSideBarViewModel : ViewModel, IHeaderSideBarViewModel
{
    private readonly IAppStateViewModel appStateViewModel;
    private readonly ICurrentUserModel currentUser;
    private readonly IPermissionExecutive permissionExecutive;
    private readonly IRequestFactory requestFactory;
    private readonly IPermissionListModel permissions;
    [ObservableProperty] private bool drawerOpen = false;
    [ObservableProperty] private bool canAccessDevTools;

    public HeaderSideBarViewModel(
        IAppStateViewModel appStateViewModel,
        ICurrentUserModel currentUser,
        IPermissionExecutive permissionExecutive,
        IRequestFactory requestFactory,
        IPermissionListModel permissions)
    {
        this.appStateViewModel = appStateViewModel;
        this.currentUser = currentUser;
        this.permissionExecutive = permissionExecutive;
        this.requestFactory = requestFactory;
        this.permissions = permissions;
        this.permissions.PermissionsChanged += PermissionsPermissionsChanged;
        this.appStateViewModel.AppStateStateChanged += AppStateViewModelPropertyChanged;
    }

    private async Task AppStateViewModelPropertyChanged()
    {        
        if (appStateViewModel.AppIsReadyToUse)
        {
            CanAccessDevTools = await permissionExecutive.HasPermission(
                requestFactory.GetCanUserViewDevToolsRequest(currentUser.CurrentUser.Permissions.Select(x => x.Id).ToList()));
        }
    }

    public void DrawerToggle() => DrawerOpen = !DrawerOpen;

    private async Task PermissionsPermissionsChanged() => await AppStateViewModelPropertyChanged();
}
