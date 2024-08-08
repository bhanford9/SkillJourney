using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Server.Apis;
using SkillJourney.Database;
using SkillJourney.Api.Server.ContractBuilders;

namespace SkillJourney.Api.Server;

public static class ServerContainer
{
    public static IServiceCollection InitializeServer(this IServiceCollection container) => DatabaseContainer
        .InitializeDatabase(container)
        .InitializeContractBuilders()
        .InitializeControllers()
        .InitializeApis();

    public static IServiceCollection InitializeContractBuilders(this IServiceCollection container) => container
        .AddSingleton<ISkillRatingContractBuilder, SkillRatingContractBuilder>()
        .AddSingleton<IBusinessAreaContractBuilder, BusinessAreaContractBuilder>()
        .AddSingleton<ISkillFieldContractBuilder, SkillFieldContractBuilder>()
        .AddSingleton<ISkillCategoryContractBuilder, SkillCategoryContractBuilder>()
        .AddSingleton<INotableHighlightContractBuilder, NotableHighlightContractBuilder>()
        .AddSingleton<INotableHighlightRelatedSkillContractBuilder, NotableHighlightRelatedSkillContractBuilder>()
        .AddSingleton<IUserContractBuilder, UserContractBuilder>()
        .AddSingleton<IPermissionContractBuilder, PermissionContractBuilder>()
        .AddSingleton<IOccupationalTitleContractBuilder, OccupationalTitleContractBuilder>()
        .AddSingleton<IContractBuilderProvider, ContractBuilderProvider>();

    private static IServiceCollection InitializeControllers(this IServiceCollection container) => container
        .AddSingleton<ISkillRatingController, SkillRatingController>()
        .AddSingleton<IBusinessAreaController, BusinessAreaController>()
        .AddSingleton<ISkillFieldController, SkillFieldController>()
        .AddSingleton<ISkillCategoryController, SkillCategoryController>()
        .AddSingleton<INotableHighlightController, NotableHighlightController>()
        .AddSingleton<IUserController, UserController>()
        .AddSingleton<IPermissionController, PermissionController>()
        .AddSingleton<IOccupationalTitleController, OccupationalTitleController>()
        .AddSingleton<IControllerProvider, ControllerProvider>();

    private static IServiceCollection InitializeApis(this IServiceCollection container) => container
        .AddSingleton<IServerStateApi, ServerStateApi>()
        .AddSingleton<ISkillRatingsApi, SkillRatingsApi>()
        .AddSingleton<INotableHighlightsApi, NotableHighlightsApi>()
        .AddSingleton<IUsersApi, UsersApi>()
        .AddSingleton<IPermissionsApi, PermissionsApi>();
}
