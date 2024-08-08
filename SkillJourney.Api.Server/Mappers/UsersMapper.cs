using Microsoft.AspNetCore.Mvc;
using SkillJourney.Api.Server.Apis;

namespace SkillJourney.Api.Server.Mappers;

public static class UsersMapper
{
    public static WebApplication MapUsers(this WebApplication app)
    {
        app.MapGet(
            "/users",
            async ([FromServices] IUsersApi api) => Results.Json(await api.GetAllUsers()));

        app.MapGet(
            "/users/{userId:guid}",
            async (Guid userId, [FromServices] IUsersApi api) => Results.Json(await api.GetUserById(userId)));

        app.MapGet(
            "/devuser",
            async ([FromServices] IUsersApi api) => Results.Json(await api.GetDevUser()));

        return app;
    }
}
