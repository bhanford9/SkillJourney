using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Database.Users;
public static class UsersDatabaseContainer
{
    public static IServiceCollection InitializeUsers(this IServiceCollection container) => container
        .AddSingleton<IUsersDatabase, UsersDatabase>()
        .AddSingleton<IUsersDatabaseApi, UsersDatabaseApi>();
}
