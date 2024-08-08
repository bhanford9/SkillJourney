using SkillJourney.Models.Users;

namespace SkillJourney.ViewModels.Users;

public interface ICurrentUserViewModel : IViewModel
{
    public bool IsLoggedIn { get; }
}

internal partial class CurrentUserViewModel : ViewModel, ICurrentUserViewModel
{
    private ICurrentUserModel currentUser;

    public CurrentUserViewModel(ICurrentUserModel currentUser) => this.currentUser = currentUser;

    public override async Task OnInitializedAsync()
    {
        await DebugLogin();
    }

    public bool IsLoggedIn => currentUser.CurrentUser is not null;

    public async Task DebugLogin() => await currentUser.DebugLogin();

    public override string ToString() => currentUser?.ToString() ?? "NO USER";
}
