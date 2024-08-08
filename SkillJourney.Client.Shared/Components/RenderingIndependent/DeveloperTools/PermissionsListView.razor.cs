using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.DeveloperTools;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent.DeveloperTools;
public partial class PermissionsListView : ComponentBase
{
    [Inject]
    public IPermissionsListViewModel ViewModel { get; set; } = default!;

    protected override Task OnInitializedAsync() => ViewModel.OnInitializedAsync();
}
