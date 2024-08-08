using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent;

public partial class MainPage : ComponentBase
{
    [Inject]
    public IServerStateViewModel ServerStateViewModel { get; set; } = default!;

    [Inject]
    public ICurrentUserViewModel CurrentUserViewModel { get; set; } = default!;

    protected override void OnInitialized()
    {
        ServerStateViewModel.ConnectionStateChanged += OnConnectionStateChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        await CurrentUserViewModel.OnInitializedAsync();
    }

    private async Task OnConnectionStateChanged()
    {
        await InvokeAsync(this.StateHasChanged);
        await CurrentUserViewModel.OnInitializedAsync();
    }
}
