using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.NotableHighlights;
internal static class NotableHighlightsDatabaseContainer
{
    public static IServiceCollection InitializeNotableHighlights(this IServiceCollection container) => container
        .AddSingleton<INotableHighlightsDatabase, NotableHighlightsDatabase>()
        .AddSingleton<INotableHighlightRelatedSkillsDatabase, NotableHighlightRelatedSkillsDatabase>()
        .AddSingleton<INotableHighlightsDatabaseApi, NotableHighlightsDatabaseApi>();
}
