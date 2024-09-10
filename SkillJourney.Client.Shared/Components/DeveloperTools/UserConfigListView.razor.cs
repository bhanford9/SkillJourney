using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels;
using SkillJourney.ViewModels.DeveloperTools;

namespace SkillJourney.Client.Shared.Components.DeveloperTools;
public partial class UserConfigListView : ComponentBase
{
    [Inject]
    public IUserConfigListViewModel ViewModel { get; set; } = default!;

    [Inject]
    public IRenderModeViewModel RenderMode { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.OnInitializedAsync();
    }
}
