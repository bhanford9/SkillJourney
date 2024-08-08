using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.SkillCategories;

namespace SkillJourney.ViewModels.SkillCategories;
public interface ISkillCategoryViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
}

internal partial class SkillCategoryViewModel : ViewModel, ISkillCategoryViewModel
{
    [ObservableProperty]
    private Guid id;
    [ObservableProperty]
    private string name;

    public SkillCategoryViewModel(ISkillCategoryModel businessArea)
    {
        id = businessArea.Id;
        name = businessArea.Name;
    }

    public override string ToString() => Name;
}
