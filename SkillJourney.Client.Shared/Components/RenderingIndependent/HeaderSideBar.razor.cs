using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent;
public partial class HeaderSideBar : ComponentBase
{
    [Inject] public IHeaderSideBarViewModel ViewModel { get; set; } = default!;
    [Inject] public IAppStateViewModel AppStateViewModel { get; set; } = default!;

    protected override Task OnInitializedAsync()
    {
        AppStateViewModel.AppStateStateChanged += AppStateViewModelAppStateStateChanged;
        return Task.CompletedTask;
    }

    private async Task AppStateViewModelAppStateStateChanged()
    {
        await InvokeAsync(StateHasChanged);
    }
}
