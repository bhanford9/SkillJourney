using Microsoft.AspNetCore.Components;

namespace SkillJourney.ViewModels;
public interface IRenderModeViewModel
{
    IComponentRenderMode? ComponentRenderMode { get; }
}
