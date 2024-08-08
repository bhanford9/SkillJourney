using SkillJourney.Api.Server;
using SkillJourney.Api.Server.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitializeServer();

var app = builder.Build();

app.UseHttpsRedirection();

app
    .MapNotableHighlights()
    .MapPermissions()
    .MapServerState()
    .MapSkillRatings()
    .MapUsers();

app.Run();
