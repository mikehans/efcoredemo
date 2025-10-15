using EFCoreDemo.DataAccess;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<FootballLeagueDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("PgCn")));
var app = builder.Build();

app.UseFastEndpoints();

app.Run();
