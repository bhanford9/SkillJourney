using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.SkillFields;
internal static class SkillFieldsDatabaseContainer
{
    public static IServiceCollection InitializeSkillFields(this IServiceCollection container) => container
        .AddSingleton<ISkillFieldsDatabase, SkillFieldsDatabase>()
        .AddSingleton<ISkillFieldsDatabaseApi, SkillFieldsDatabaseApi>();
}
