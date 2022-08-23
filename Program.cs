using Opendata;
using Microsoft.EntityFrameworkCore;
using Opendata.Infrastructure;
using Opendata.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<DbContext, SQLContext>();
        services.AddHostedService<Worker>();
        services.AddSingleton<ITDXService, TDXService>();
    })
    .Build();

await host.RunAsync();
