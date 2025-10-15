using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFCoreDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello world");

var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((ctx, svcs) =>
            {
                svcs.AddDbContext<FootballLeagueDbContext>(opts => 
                    opts.UseNpgsql(ctx.Configuration.GetConnectionString("PgCn")));
            })
            .Build();

// write to the DB here
using var context = host.Services.GetRequiredService<FootballLeagueDbContext>();

await context.Database.EnsureCreatedAsync();

var testawait context.Leagues.FirstOrDefaultAsync(l => l.Name = "AFL");
if ()


await host.RunAsync();