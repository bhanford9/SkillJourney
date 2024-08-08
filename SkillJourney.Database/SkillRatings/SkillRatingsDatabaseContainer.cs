using Microsoft.Extensions.DependencyInjection;
using SkillJourney.Database.SkillRatings.SoftwareEngineering.Management;

namespace SkillJourney.Database.SkillRatings;
internal static class SkillRatingsDatabaseContainer
{
    public static IServiceCollection InitializeSkillRatings(this IServiceCollection container) => container
        .AddSingleton<ISkillRatingNaming, SkillRatingNaming>()
        .AddSingleton<ISkillRatingsDatabase, SkillRatingsDatabase>()
        
        .AddTransient<ISkillRatings, ProcessEngineeringSkills>()
        .AddTransient<ISkillRatings, ProjectManagementSkills>()
        
        .AddSingleton<ISkillRatingsDatabaseApi, SkillRatingsDatabaseApi>();
}
