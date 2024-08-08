using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.Users;
using SkillJourney.ViewModels.NotableHighlights;
using SkillJourney.ViewModels.OccupationalTitles;
using SkillJourney.ViewModels.Permissions;

namespace SkillJourney.ViewModels.Users;
public interface IUserViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
    public IOccupationalTitleViewModel Title { get; set; }
    ObservableCollection<IPermissionViewModel> Permissions { get; }
    ObservableCollection<INotableHighlightViewModel> Highlights { get; }
}

internal partial class UserViewModel : ViewModel, IUserViewModel
{
    [ObservableProperty] private Guid id;
    [ObservableProperty] private string name;
    [ObservableProperty] private IOccupationalTitleViewModel title;

    public UserViewModel(IUserModel user, IViewModelFactory viewModelFactory)
    {
        id = user.Id;
        name = user.Name;
        title = viewModelFactory.BuildTitle(user.OccupationalTitle);
        Permissions = new ObservableCollection<IPermissionViewModel>(user.Permissions.Select(viewModelFactory.BuildPermission));
        Highlights = new ObservableCollection<INotableHighlightViewModel>(user.Highlights.Select(viewModelFactory.BuildNotableHighlight));
    }

    public ObservableCollection<IPermissionViewModel> Permissions { get; }

    public ObservableCollection<INotableHighlightViewModel> Highlights { get; }

    public override string ToString() => Name;
}
