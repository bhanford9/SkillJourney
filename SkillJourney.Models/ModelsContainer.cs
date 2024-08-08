using Microsoft.Extensions.DependencyInjection;
using SkillJourney.Api.Client;
using SkillJourney.Models.BusinessAreas;
using SkillJourney.Models.ContractAdapters;
using SkillJourney.Models.Messages;
using SkillJourney.Models.NotableHighlights;
using SkillJourney.Models.OccupationalTitles;
using SkillJourney.Models.Permissions;
using SkillJourney.Models.SkillCategories;
using SkillJourney.Models.SkillFields;
using SkillJourney.Models.SkillRatings;
using SkillJourney.Models.Users;
using SkillJourney.PermissionsEngine;

namespace SkillJourney.Models;
public static class ModelsContainer
{
    public static IServiceCollection InitializeModels(this IServiceCollection container) => container
        .InitializeClientApi()
        .InitializeMessages()
        .InitializeServerState()
        .InitializeSkillRatings()
        .InitializeBusinessAreas()
        .InitializeSkillFields()
        .InitializeSkillCategories()
        .InitializeNotableHighlights()
        .InitializeOccupationalTitles()
        .InitializePermissions()
        .InitializeUsers()
        .InitializePermissionsEngine();

    private static IServiceCollection InitializeMessages(this IServiceCollection container) => container
        .AddSingleton<IMessagesFactory, MessagesFactory>();

    private static IServiceCollection InitializeServerState(this IServiceCollection container) => container
        .AddSingleton<IServerState, ServerState>()
        .AddSingleton<IServerStateMonitor, ServerStateMonitor>();

    private static IServiceCollection InitializeSkillRatings(this IServiceCollection container) => container
        .AddSingleton<ISkillRatingFactory, SkillRatingFactory>()
        .AddSingleton<ISkillRatingsAdapter, SkillRatingsAdapter>()
        .AddTransient<ISkillRatings, SkillRatings.SkillRatings>();

    private static IServiceCollection InitializeBusinessAreas(this IServiceCollection container) => container
        .AddSingleton<IBusinessAreaFactory, BusinessAreaFactory>()
        .AddSingleton<IBusinessAreasAdapter, BusinessAreasAdapter>();

    private static IServiceCollection InitializeSkillCategories(this IServiceCollection container) => container
        .AddSingleton<ISkillCategoryFactory, SkillCategoryFactory>()
        .AddSingleton<ISkillCategoriesAdapter, SkillCategoriesAdapter>();

    private static IServiceCollection InitializeSkillFields(this IServiceCollection container) => container
        .AddSingleton<ISkillFieldFactory, SkillFieldFactory>()
        .AddSingleton<ISkillFieldsAdapter, SkillFieldsAdapter>();

    private static IServiceCollection InitializeNotableHighlights(this IServiceCollection container) => container
        .AddSingleton<INotableHighlightFactory, NotableHighlightFactory>()
        .AddSingleton<INotableHighlightsAdapter, NotableHighlightsAdapter>()
        .AddTransient<INotableHighlightsListModel, NotableHighlightsListModel>();

    private static IServiceCollection InitializeOccupationalTitles(this IServiceCollection container) => container
        .AddSingleton<IOccupationalTitleFactory, OccupationalTitleFactory>()
        .AddSingleton<IOccupationalTitlesAdapter, OccupationalTitlesAdapter>();

    private static IServiceCollection InitializePermissions(this IServiceCollection container) => container
        .AddSingleton<IPermissionFactory, PermissionFactory>()
        .AddSingleton<IPermissionListModel, PermissionListModel>()
        .AddSingleton<IPermissionsAdapter, PermissionsAdapter>();

    private static IServiceCollection InitializeUsers(this IServiceCollection container) => container
        .AddSingleton<IUserFactory, UserFactory>()
        .AddSingleton<IUsersAdapter, UsersAdapter>()
        .AddSingleton<ICurrentUserModel, CurrentUserModel>()
        .AddSingleton<IUserListModel, UserListModel>()
        .AddSingleton<IUserService, UserService>();
}
