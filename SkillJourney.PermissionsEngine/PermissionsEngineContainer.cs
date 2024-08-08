using Microsoft.Extensions.DependencyInjection;
using SkillJourney.PermissionsEngine.Evaluators;
using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine;

// TODO --> put this somewhere more accessible
public static class DependencyInjectionUtils
{
    public static IServiceCollection AddTransient<TParentInterface, TInterface, TClass>(this IServiceCollection container)
        where TClass : class, TInterface
        where TInterface : class, TParentInterface
        where TParentInterface : class
        => container
        .AddTransient<TParentInterface, TClass>()
        .AddTransient<TInterface, TClass>();
}

public static class PermissionsEngineContainer
{
    public static IServiceCollection InitializePermissionsEngine(this IServiceCollection container) => container
        .AddSingleton<IEvaluatorRepository, EvaluatorRepository>()
        .AddSingleton<IPermissionExecutive, PermissionExecutive>()
        .AddSingleton<IRequestFactory, RequestFactory>()
        .InitializeRequests()
        .InitializeEvaluators();

    private static IServiceCollection InitializeRequests(this IServiceCollection container) => container
        .AddTransient<IPermissionRequest, ICanUserViewDevToolsRequest, CanUserViewDevToolsRequest>()
        .AddTransient<IPermissionRequest, ICanUserViewProfilesRequest, CanUserViewProfilesRequest>();

    private static IServiceCollection InitializeEvaluators(this IServiceCollection container) => container
        .AddTransient<IPermissionEvaluator, ICanViewDevToolsEvaluator, CanViewDevToolsEvaluator>()
        .AddTransient<IPermissionEvaluator, ICanViewProfilesEvaluator, CanViewProfilesEvaluator>();
}
