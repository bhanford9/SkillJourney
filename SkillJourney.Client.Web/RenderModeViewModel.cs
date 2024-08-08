using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SkillJourney.ViewModels;

namespace SkillJourney.Client.Web;

public class RenderModeViewModel : IRenderModeViewModel
{
    public IComponentRenderMode? ComponentRenderMode => RenderMode.InteractiveServer;
}
