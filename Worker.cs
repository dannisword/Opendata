using System.Diagnostics;
using Opendata.Models;
using Opendata.Services;
using Opendata.Infrastructure;

namespace Opendata;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;
    private readonly ITDXService _tdxService;

    private readonly IOpendataService _opendataService;
    public Worker(
        ILogger<Worker> logger,
        IConfiguration configuration,
        ITDXService tdxService,
        IOpendataService opendataService
        )
    {
        this._logger = logger;
        this._configuration = configuration;
        this._tdxService = tdxService;
        this._opendataService = opendataService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // 高鐵轉檔
        await this._tdxService.HandleDailyTimetable();
        // 裁決書
        await this._opendataService.GetJDocs2();
        Environment.Exit(0);
    }
}
