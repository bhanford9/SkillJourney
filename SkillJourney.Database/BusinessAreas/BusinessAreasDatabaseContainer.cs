using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.BusinessAreas;
public static class BusinessAreasDatabaseContainer
{
    public static IServiceCollection InitializeBusinessAreas(this IServiceCollection container) => container
        .AddSingleton<IBusinessAreasDatabase, BusinessAreasDatabase>()
        .AddSingleton<IBusinessAreasDatabaseApi, BusinessAreasDatabaseApi>();
}
