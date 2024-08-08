using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.OccupationalTitles;
public static class OccupationalTitlesDatabaseContainer
{
    public static IServiceCollection InitializeOccupationalTitles(this IServiceCollection container) => container
        .AddSingleton<IOccupationalTitlesDatabase, OccupationalTitlesDatabase>()
        .AddSingleton<IOccupationalTitlesDatabaseApi, OccupationalTitlesDatabaseApi>();
}
