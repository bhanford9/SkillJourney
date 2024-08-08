using Microsoft.AspNetCore.Components;
using MudBlazor;
using SkillJourney.ViewModels.NotableHighlights;

namespace SkillJourney.Client.Shared.Components.RenderingIndependent;
public partial class NotableHighlightForm : ComponentBase
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    [Inject]
    public INotableHighlightFormViewModel ViewModel { get; set; } = default!;

    private void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
        ViewModel.NotifyFormComplete();
    }

    private void Cancel() => MudDialog.Cancel();
}
