using System.Collections.ObjectModel;
using SkillJourney.Models.SkillRatings;

namespace SkillJourney.ViewModels.SkillRatings;
public interface ISkillRatingListViewModel : IViewModel
{
    ObservableCollection<ISkillRatingViewModel> SkillRatings { get; }
}

internal partial class SkillRatingListViewModel : ViewModel, ISkillRatingListViewModel
{
    private readonly ISkillRatings skillRatings;
    private readonly IViewModelFactory viewModelFactory;

    public SkillRatingListViewModel(ISkillRatings skillRatings, IViewModelFactory viewModelFactory)
    {
        this.skillRatings = skillRatings;
        this.viewModelFactory = viewModelFactory;
    }

    public ObservableCollection<ISkillRatingViewModel> SkillRatings { get; } = [];

    public override async Task OnInitializedAsync()
    {
        await skillRatings.GetAllRatings();
        foreach (var rating in skillRatings.Ratings)
            SkillRatings.Add(viewModelFactory.BuildSkillRating(rating));
    }
}
