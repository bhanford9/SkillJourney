using Microsoft.Extensions.DependencyInjection;
using SkillJourney.Api.Client.ApiClients;

namespace SkillJourney.Api.Client;
public static class ClientContainer
{
    public static IServiceCollection InitializeClientApi(this IServiceCollection container) => container
        .AddSingleton<IServerConfiguration, ServerConfiguration>()
        .InitializeClients();

    private static IServiceCollection InitializeClients(this IServiceCollection container) => container
        .AddTransient<IServerStateClient, ServerStateClient>()
        .AddTransient<IUsersClient, UsersClient>()
        .AddTransient<ISkillRatingsClient, SkillRatingsClient>()
        .AddTransient<INotableHighlightsClient, NotableHighlightsClient>()
        .AddTransient<IPermissionsClient, PermissionsClient>();

}
