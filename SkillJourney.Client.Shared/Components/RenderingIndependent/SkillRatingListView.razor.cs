using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.SkillRatings;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent;

public partial class SkillRatingListView : ComponentBase
{
    [Inject]
    public ISkillRatingListViewModel ViewModel { get; set; } = default!;

    protected override Task OnInitializedAsync() => ViewModel.OnInitializedAsync();
}
