using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.Permissions;
using SkillJourney.Models.Users;
using SkillJourney.PermissionsEngine;
using SkillJourney.ViewModels.Utilities;

namespace SkillJourney.ViewModels.Users;

public interface IEmployeesListViewModel : IViewModel
{
    ObservableCollection<IUserViewModel> Employees { get; }
    bool CannotViewProfiles { get; set; }
}

internal partial class EmployeesListViewModel : ViewModel, IEmployeesListViewModel
{
    private readonly IUserListModel userListModel;
    private readonly IViewModelFactory viewModelFactory;
    private readonly ICurrentUserModel currentUser;
    private readonly IPermissionExecutive permissionExecutive;
    private readonly IRequestFactory requestFactory;
    private readonly IPermissionListModel permissions;
    [ObservableProperty] private bool cannotViewProfiles;

    public EmployeesListViewModel(
        IUserListModel userListModel,
        IViewModelFactory viewModelFactory,
        ICurrentUserModel currentUser,
        IPermissionExecutive permissionExecutive,
        IRequestFactory requestFactory,
        IPermissionListModel permissions)
    {
        this.userListModel = userListModel;
        this.viewModelFactory = viewModelFactory;
        this.currentUser = currentUser;
        this.permissionExecutive = permissionExecutive;
        this.requestFactory = requestFactory;
        this.permissions = permissions;
        this.permissions.PermissionsChanged += PermissionsPermissionsChanged;
    }

    public ObservableCollection<IUserViewModel> Employees { get; } = [];

    public override async Task OnInitializedAsync()
    {
        Employees.ClearAndAddRange((await userListModel.InitializeUsers()).Select(viewModelFactory.BuildUser));
        await CheckAbilityToViewProiles();
    }

    private async Task CheckAbilityToViewProiles()
        => CannotViewProfiles = !await permissionExecutive.HasPermission(
            requestFactory.GetCanUserViewProfilesRequest(currentUser.CurrentUser.Permissions.Select(x => x.Id).ToList()));

    private async Task PermissionsPermissionsChanged() => await CheckAbilityToViewProiles();
}
