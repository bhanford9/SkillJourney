using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SkillJourney.ViewModels;

public interface IViewModel : INotifyPropertyChanged
{
    Task OnInitializedAsync();
}

internal abstract class ViewModel : ObservableObject, IViewModel
{
    public virtual Task OnInitializedAsync() => Task.CompletedTask;
}
