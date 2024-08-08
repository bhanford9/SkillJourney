using Microsoft.AspNetCore.Mvc;
using SkillJourney.Api.Server.Apis;

namespace SkillJourney.Api.Server.Mappers;

public static class ServerStateMapper
{
    public static WebApplication MapServerState(this WebApplication app)
    {
        app.MapGet(
            "/state",
            async ([FromServices] IServerStateApi api) => Results.Json(await api.GetState()));

        return app;
    }
}
