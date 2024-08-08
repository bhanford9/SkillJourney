using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.SkillFields;

namespace SkillJourney.ViewModels.SkillFields;
public interface ISkillFieldViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
}

internal partial class SkillFieldViewModel : ViewModel, ISkillFieldViewModel
{
    [ObservableProperty]
    private Guid id;
    [ObservableProperty]
    private string name;

    public SkillFieldViewModel(ISkillFieldModel businessArea)
    {
        id = businessArea.Id;
        name = businessArea.Name;
    }

    public override string ToString() => Name;
}
