﻿using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.Permissions;

namespace SkillJourney.Api.Server.Apis;

public interface IPermissionsApi
{
    Task<IReadOnlyList<PermissionContract>> GetAllPermissions();
    Task<PermissionContract> GetDevUserPermission();
    Task<PermissionContract> GetViewUserHighlightsPermission();
    Task<IReadOnlyList<PermissionContract>> UpdatePermissions(IReadOnlyList<PermissionContract> permissions);
}

public class PermissionsApi : IPermissionsApi
{
    private readonly IPermissionController permissionController;

    public PermissionsApi(IPermissionController permissionController) => this.permissionController = permissionController;

    public Task<PermissionContract> GetDevUserPermission() => Task.FromResult(permissionController.GetDevUserPermission());

    public Task<PermissionContract> GetViewUserHighlightsPermission() => Task.FromResult(permissionController.GetViewUserHighlightsPermission());

    public Task<IReadOnlyList<PermissionContract>> GetAllPermissions() => Task.FromResult(permissionController.GetAllPermissions());

    public Task<IReadOnlyList<PermissionContract>> UpdatePermissions(IReadOnlyList<PermissionContract> permissions) 
        => Task.FromResult(permissionController.UpdatePermissions(permissions));
}
