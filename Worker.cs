using System.Diagnostics;
using Opendata.Models;
using Opendata.Services;
using Opendata.Infrastructure;

namespace Opendata;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    private readonly ITDXService _tdx;
    public Worker(
        ILogger<Worker> logger,
        IConfiguration configuration,
        ITDXService tdx)
    {
        this._logger = logger;
        this._configuration = configuration;
        this._tdx = tdx;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this._tdx.HandleDailyTimetable();
        var now = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        Environment.Exit(0);
    }
}
