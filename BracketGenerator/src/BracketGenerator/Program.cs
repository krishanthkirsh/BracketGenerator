using BracketGenerator;
using BracketGenerator.Interfaces;
using BracketGenerator.SeedData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<ISeedData, SeedData>();
        services.AddServiceMapppings();
    })
    .Build();

var app = _host.Services.GetRequiredService<ITournamentGenerator>();
app.RunAsyn();