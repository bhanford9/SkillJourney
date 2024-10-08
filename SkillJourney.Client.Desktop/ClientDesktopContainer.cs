﻿using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using SkillJourney.Client.Shared;
using SkillJourney.ViewModels;

namespace SkillJourney.Client.Desktop;
internal class ClientDesktopContainer
{
    public static IServiceCollection InitializeGui()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection
            .AddMudServices()
            .AddHttpClient()
            .AddSingleton<IRenderModeViewModel, RenderModeViewModel>()
            .AddTransient<IMessenger>(_ => WeakReferenceMessenger.Default); // using weak for simplicity

#if DEBUG
        serviceCollection.AddBlazorWebViewDeveloperTools(); // use F12 or Ctrl+Shift+I to use in app
#endif

        return serviceCollection.InitializeSharedContainer();
    }
}
