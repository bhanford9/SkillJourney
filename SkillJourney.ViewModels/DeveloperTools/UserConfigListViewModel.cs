using System.Collections.ObjectModel;
using SkillJourney.Models.Users;
using SkillJourney.ViewModels.Utilities;

namespace SkillJourney.ViewModels.DeveloperTools;
public interface IUserConfigListViewModel : IViewModel
{
    ObservableCollection<IUserConfigListItemViewModel> Users { get; }
}

internal partial class UserConfigListViewModel : ViewModel, IUserConfigListViewModel
{
    private readonly IUserListModel usersList;
    private readonly IViewModelFactory viewModelFactory;

    public UserConfigListViewModel(IUserListModel usersList, IViewModelFactory viewModelFactory)
    {
        this.usersList = usersList;
        this.viewModelFactory = viewModelFactory;
    }

    public ObservableCollection<IUserConfigListItemViewModel> Users { get; } = [];

    public override async Task OnInitializedAsync()
    {
        Users.ClearAndAddRange((await usersList.InitializeUsers()).Select(viewModelFactory.BuildUserConfigListItem));
    }
}
