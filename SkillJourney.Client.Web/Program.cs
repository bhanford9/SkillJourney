using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.FileProviders;
using MudBlazor.Services;
using SkillJourney.Client.Shared.Components;
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

var sharedRootPath = builder.Environment.WebRootPath.Replace("SkillJourney.Client.Web", "SkillJourney.Client.Shared");
app.UseStaticFiles();
app.UseStaticFiles( new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(sharedRootPath),
});
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(MainPage).Assembly)
    .AddInteractiveServerRenderMode();

app.Run();
