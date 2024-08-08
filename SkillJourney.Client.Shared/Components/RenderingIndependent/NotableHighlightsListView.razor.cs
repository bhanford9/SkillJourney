using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.NotableHighlights;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent;
public partial class NotableHighlightsListView : ComponentBase
{
    [Inject]
    public INotableHighlightsListViewModel ViewModel { get; set; } = default!;

    protected override Task OnInitializedAsync() => ViewModel.OnInitializedAsync();
}
