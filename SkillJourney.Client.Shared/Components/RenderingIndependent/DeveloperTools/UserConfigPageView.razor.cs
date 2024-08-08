using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent.DeveloperTools;
public partial class UserConfigPageView : ComponentBase
{
    [Inject]
    private IViewModelFactory ViewModelFactory { get; set; } = default!;

    [Parameter]
    public Guid Id { get; set; }

    public IUserViewModel User { get; private set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        User = await ViewModelFactory.BuildUser(Id);
    }
}
