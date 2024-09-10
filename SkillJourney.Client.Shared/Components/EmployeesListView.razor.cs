using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.Client.Shared.Components;
public partial class EmployeesListView : ComponentBase
{
    [Inject]
    public IEmployeesListViewModel ViewModel { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.OnInitializedAsync();
    }
}
