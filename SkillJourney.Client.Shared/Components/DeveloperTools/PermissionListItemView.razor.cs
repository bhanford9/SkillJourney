﻿using Microsoft.AspNetCore.Components;
using SkillJourney.ViewModels.DeveloperTools;

namespace SkillJourney.Client.Shared.Components.DeveloperTools;
public partial class PermissionListItemView : ComponentBase
{
    [Parameter]
    public IPermissionsListItemViewModel ViewModel { get; set; } = default!;
}
