using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.TitlePermissionPermissions;
public static class TitlePermissionsDatabaseContainer
{
    public static IServiceCollection InitializeTitlePermissions(this IServiceCollection container) => container
        .AddSingleton<ITitlePermissionsDatabase, TitlePermissionsDatabase>()
        .AddSingleton<ITitlePermissionsDatabaseApi, TitlePermissionsDatabaseApi>();
}
