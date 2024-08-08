using Microsoft.Extensions.DependencyInjection;
using SkillJourney.Models;
using SkillJourney.ViewModels.DeveloperTools;
using SkillJourney.ViewModels.Messages;
using SkillJourney.ViewModels.NotableHighlights;
using SkillJourney.ViewModels.SkillRatings;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.ViewModels;
public static class ViewModelsContainer
{
    public static IServiceCollection InitializeViewModels(this IServiceCollection container) => container
        .InitializeModels()
        .AddSingleton<IViewModelFactory, ViewModelFactory>()
        .AddSingleton<IMessagesFactory, MessagesFactory>()
        .AddSingleton<IAppStateViewModel, AppStateViewModel>()
        .AddSingleton<IServerStateViewModel, ServerStateViewModel>()
        .AddSingleton<ICurrentUserViewModel, CurrentUserViewModel>()
        .AddSingleton<IHeaderSideBarViewModel, HeaderSideBarViewModel>()
        .AddSingleton<IEmployeesListViewModel, EmployeesListViewModel>()
        .AddTransient<ISkillRatingListViewModel, SkillRatingListViewModel>()
        .AddTransient<INotableHighlightsListViewModel, NotableHighlightsListViewModel>()
        .AddTransient<INotableHighlightFormViewModel, NotableHighlightFormViewModel>()
        .AddTransient<IUserConfigListViewModel, UserConfigListViewModel>()
        .AddTransient<IPermissionsListViewModel, PermissionsListViewModel>();
}
