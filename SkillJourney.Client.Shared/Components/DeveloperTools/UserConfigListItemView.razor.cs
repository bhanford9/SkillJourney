using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.DeveloperTools;

namespace SkillJourney.Client.Shared.Components.DeveloperTools;
public partial class UserConfigListItemView : ComponentBase
{
    [Parameter]
    public IUserConfigListItemViewModel ViewModel { get; set; } = default!;

    private void GoToUserConfigPage()
    {
        NavManager.NavigateTo($"/developer-user/{ViewModel.User.Id}");
    }
}
