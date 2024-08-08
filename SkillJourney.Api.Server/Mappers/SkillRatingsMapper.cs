using Microsoft.AspNetCore.Mvc;
using SkillJourney.Api.Server.Apis;

namespace SkillJourney.Api.Server.Mappers;

public static class SkillRatingsMapper
{
    public static WebApplication MapSkillRatings(this WebApplication app)
    {
        app.MapGet(
            "/skillratings",
            async ([FromServices] ISkillRatingsApi api) => Results.Json(await api.GetAllSkillRatings()));

        return app;
    }
}
