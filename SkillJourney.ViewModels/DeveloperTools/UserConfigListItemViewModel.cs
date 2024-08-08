using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.ViewModels.DeveloperTools;

public interface IUserConfigListItemViewModel : IViewModel
{
    IUserViewModel User { get; }
}

internal partial class UserConfigListItemViewModel : ViewModel, IUserConfigListItemViewModel
{
    [ObservableProperty] private IUserViewModel user;

    public UserConfigListItemViewModel(IUserViewModel user)
    {
        this.user = user;
    }
}
