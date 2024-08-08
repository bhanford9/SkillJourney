using System.ComponentModel;
using SkillJourney.ViewModels.Users;
using static SkillJourney.ViewModels.AppStateEvents;

namespace SkillJourney.ViewModels;

public class AppStateEvents
{
    public delegate Task AppStateChangedHandler();
}
public interface IAppStateViewModel : IViewModel
{
    bool AppIsReadyToUse { get; }
    bool ConnectedToServer { get; }
    bool IsLoggedIn { get; }

    event AppStateChangedHandler? AppStateStateChanged;
}

internal class AppStateViewModel : ViewModel, IAppStateViewModel
{
    private readonly IServerStateViewModel serverStateViewModel;
    private readonly ICurrentUserViewModel currentUserViewModel;

    public event AppStateChangedHandler? AppStateStateChanged;

    public AppStateViewModel(
        IServerStateViewModel serverStateViewModel,
        ICurrentUserViewModel currentUserViewModel)
    {
        this.serverStateViewModel = serverStateViewModel;
        this.currentUserViewModel = currentUserViewModel;

        serverStateViewModel.ConnectionStateChanged += ServerStateViewModelConnectionStateChanged; ;
        currentUserViewModel.PropertyChanged += CurrentUserViewModelPropertyChanged;
    }

    private Task ServerStateViewModelConnectionStateChanged()
    {
        OnPropertyChanged(nameof(ConnectedToServer));
        AppStateStateChanged?.Invoke();
        return Task.CompletedTask;
    }

    private void CurrentUserViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(currentUserViewModel.IsLoggedIn))
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            AppStateStateChanged?.Invoke();
        }
    }

    public bool IsLoggedIn => currentUserViewModel.IsLoggedIn;

    public bool ConnectedToServer => serverStateViewModel.IsConnected;

    public bool AppIsReadyToUse => IsLoggedIn && ConnectedToServer;
}
