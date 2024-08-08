using CommunityToolkit.Mvvm.Messaging;
using MudBlazor.Services;
using SkillJourney.Client.Shared.Components.RenderingIndependent;
using SkillJourney.Client.Web;
using SkillJourney.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InitializeViewModels()
    .AddSingleton<IRenderModeViewModel, RenderModeViewModel>()
    .AddTransient<IMessenger>(_ => WeakReferenceMessenger.Default) // using weak for simplicity
    .AddMudServices()
    .AddHttpClient()
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(MainPage).Assembly)
    .AddInteractiveServerRenderMode();

app.Run();
