using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.BusinessAreas;

namespace SkillJourney.ViewModels.BusinessAreas;
public interface IBusinessAreaViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
}

internal partial class BusinessAreaViewModel : ViewModel, IBusinessAreaViewModel
{
    [ObservableProperty]
    private Guid id;
    [ObservableProperty]
    private string name;

    public BusinessAreaViewModel(IBusinessAreaModel businessArea)
    {
        id = businessArea.Id;
        name = businessArea.Name;
    }

    public override string ToString() => this.Name;
}
