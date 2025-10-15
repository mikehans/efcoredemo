using EFCoreDemo.DataAccess;
using EFCoreDemo.Web.Contracts;
using EFCoreDemo.Web.Services;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ILeagueService, LeagueService>();

builder.Services.AddDbContext<FootballLeagueDbContext>(opts =>
    opts.UseNpgsql(builder.Configuration.GetConnectionString("PgCn"))
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging()
);
var app = builder.Build();

app.UseFastEndpoints();

app.Run();
