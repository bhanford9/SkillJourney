using Microsoft.AspNetCore.Mvc;
using SkillJourney.Api.Server.Apis;
using SkillJourney.Api.Shared.Contract.NotableHighlights;

namespace SkillJourney.Api.Server.Mappers;

public static class NotableHighlightsMapper
{
    public static WebApplication MapNotableHighlights(this WebApplication app)
    {
        app.MapGet(
            "/highlights/{userId:guid}",
            async (Guid userId, [FromServices] INotableHighlightsApi api)
            => Results.Json(await api.GetHighlightsForUser(userId)));

        app.MapPost(
            "/add-highlight",
            async ([FromServices] INotableHighlightsApi api, [FromBody] AddNotableHighlightContract highlightData)
            => Results.Json(await api.AddHighlight(highlightData)));

        return app;
    }
}
