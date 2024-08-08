using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.SkillRatings;
using SkillJourney.ViewModels.BusinessAreas;
using SkillJourney.ViewModels.SkillCategories;
using SkillJourney.ViewModels.SkillFields;

namespace SkillJourney.ViewModels.SkillRatings;

public interface ISkillRatingViewModel
{
    Guid Id { get; }
    string Description { get; }
    IBusinessAreaViewModel BusinessArea { get; }
    ISkillFieldViewModel SkillField { get; }
    ISkillCategoryViewModel SkillCategory { get; }
    string Name { get; }
    int Value { get; }
    bool IsObsolete { get; }
    ISkillRatingModel SkillRatingModel { get; }
}
internal partial class SkillRatingViewModel : ObservableObject, ISkillRatingViewModel
{
    private readonly IViewModelFactory viewModelFactory;
    [ObservableProperty] private Guid id;
    [ObservableProperty] private string description;
    [ObservableProperty] private IBusinessAreaViewModel businessArea;
    [ObservableProperty] private ISkillFieldViewModel skillField;
    [ObservableProperty] private ISkillCategoryViewModel skillCategory;
    [ObservableProperty] private string name;
    [ObservableProperty] private int value;
    [ObservableProperty] private bool isObsolete;

    public SkillRatingViewModel(ISkillRatingModel skillRating, IViewModelFactory viewModelFactory)
    {
        this.SkillRatingModel = skillRating;
        id = skillRating.Id;
        description = skillRating.Description;
        businessArea = viewModelFactory.BuildBusinessArea(skillRating.BusinessArea);
        skillField = viewModelFactory.BuildSkillField(skillRating.SkillField);
        skillCategory = viewModelFactory.BuildSkillCategory(skillRating.SkillCategory);
        name = skillRating.Name;
        value = (int)skillRating.Value;
        isObsolete = skillRating.IsObsolete;
        this.viewModelFactory = viewModelFactory;
    }

    public ISkillRatingModel SkillRatingModel { get; }
}
