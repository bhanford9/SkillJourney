using CommunityToolkit.Mvvm.ComponentModel;
using SkillJourney.Models.NotableHighlights;
using SkillJourney.ViewModels.SkillRatings;

namespace SkillJourney.ViewModels.NotableHighlights;
public interface INotableHighlightViewModel : IViewModel
{
    public Guid Id { get; }
    public int SignificanceRating { get; }
    public string Description { get; }
    public DateTime DateOfOccurrence { get; }
    public string RelatedSkillsRollup { get; }
    public IReadOnlyList<ISkillRatingViewModel> RelatedSkillRatings { get; }
}

internal partial class NotableHighlightViewModel : ViewModel, INotableHighlightViewModel
{
    private readonly IViewModelFactory viewModelFactory;
    [ObservableProperty] Guid id;
    [ObservableProperty] int significanceRating;
    [ObservableProperty] string description;
    [ObservableProperty] DateTime dateOfOccurrence;
    [ObservableProperty] IReadOnlyList<ISkillRatingViewModel> relatedSkillRatings;

    public NotableHighlightViewModel(INotableHighlightModel notableHighlight, IViewModelFactory viewModelFactory)
    {
        id = notableHighlight.Id;
        significanceRating = notableHighlight.SignificanceRating;
        description = notableHighlight.Description;
        dateOfOccurrence = notableHighlight.DateOfOccurrence;
        relatedSkillRatings = notableHighlight.RelatedSkillRatings.Select(viewModelFactory.BuildSkillRating).ToList();
        this.viewModelFactory = viewModelFactory;
    }

    public string RelatedSkillsRollup => string.Join(Environment.NewLine, RelatedSkillRatings.Select(x => x.Name));
}
