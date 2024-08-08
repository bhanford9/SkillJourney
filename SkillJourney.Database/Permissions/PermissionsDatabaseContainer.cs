using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.Permissions;
public static class PermissionsDatabaseContainer
{
    public static IServiceCollection InitializePermissions(this IServiceCollection container) => container
        .AddSingleton<IPermissionsDatabase, PermissionsDatabase>()
        .AddSingleton<IPermissionsDatabaseApi, PermissionsDatabaseApi>();
}
