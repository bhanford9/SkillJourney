using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.NotableHighlights;

namespace SkillJourney.Client.Shared.Components;
public partial class NotableHighlightsListView : ComponentBase
{
    [Inject]
    public INotableHighlightsListViewModel ViewModel { get; set; } = default!;

    protected override Task OnInitializedAsync() => ViewModel.OnInitializedAsync();
}
