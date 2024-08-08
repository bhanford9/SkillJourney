using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.UserPermissionPermissions;
public static class UserPermissionsDatabaseContainer
{
    public static IServiceCollection InitializeUserPermissions(this IServiceCollection container) => container
        .AddSingleton<IUserPermissionsDatabase, UserPermissionsDatabase>()
        .AddSingleton<IUserPermissionsDatabaseApi, UserPermissionsDatabaseApi>();
}
