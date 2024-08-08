using Microsoft.AspNetCore.Mvc;
using SkillJourney.Api.Server.Apis;
using SkillJourney.Api.Shared.Contract.Permissions;

namespace SkillJourney.Api.Server.Mappers;

public static class PermissionsMapper
{
    public static WebApplication MapPermissions(this WebApplication app)
    {
        app.MapGet(
            "/permission-devuser",
            async ([FromServices] IPermissionsApi api) => Results.Json(await api.GetDevUserPermission()));
        app.MapGet(
            "/permission-ViewUserHighlightsPermission",
            async ([FromServices] IPermissionsApi api) => Results.Json(await api.GetViewUserHighlightsPermission()));

        app.MapGet(
            "/permissions-list",
            async ([FromServices] IPermissionsApi api) => Results.Json(await api.GetAllPermissions()));

        app.MapPost(
            "/permissions-update",
            async ([FromServices] IPermissionsApi api, IReadOnlyList<PermissionContract> permissions)
                => Results.Json(await api.UpdatePermissions(permissions)));

        return app;
    }
}
