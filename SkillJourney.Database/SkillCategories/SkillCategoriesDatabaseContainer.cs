using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.SkillCategories;
internal static class SkillCategoriesDatabaseContainer
{
    public static IServiceCollection InitializeSkillCategories(this IServiceCollection container) => container
        .AddSingleton<ISkillCategoriesDatabase, SkillCategoriesDatabase>()
        .AddSingleton<ISkillCategoriesDatabaseApi, SkillCategoriesDatabaseApi>();
}
