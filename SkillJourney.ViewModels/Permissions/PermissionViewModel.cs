using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.Permissions;

namespace SkillJourney.ViewModels.Permissions;
public interface IPermissionViewModel : IViewModel
{
    Guid Id { get; }

    string Name { get; set; }
    bool IsDeprecated { get; set; }
}

internal partial class PermissionViewModel : ViewModel, IPermissionViewModel
{
    private readonly IPermissionModel model;
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private bool isDeprecated = false;

    public PermissionViewModel(IPermissionModel model)
    {
        this.model = model;
        Name = model.Name;
        IsDeprecated = model.IsDeprecated;
    }

    public Guid Id => model.Id;
}
