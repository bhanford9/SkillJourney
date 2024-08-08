using Microsoft.Extensions.DependencyInjection;
using SkillJourney.ViewModels;

namespace SkillJourney.Client.Shared;
public static class ClientSharedContainer
{
    public static IServiceCollection InitializeSharedContainer(this IServiceCollection container) => container
        .InitializeViewModels();
}
