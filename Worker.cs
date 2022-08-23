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
        //_logger.LogInformation($"Value {resp.Value.ToString()}");
        //System.Diagnostics.Debug.WriteLine(resp.Value.ToString());

        //var resp = await srv.PostRequest(url, auth);
        //var token = (OpendataToken)resp.Value;

        /*
        var token = tdx.GetOpendataToken();
        var jDocs = tdx.GetJDocs(token);
        using (var context = new SQLContext(this._configuration))
        {
            context.CourtVerdicts.AddRange(jDocs);
            context.SaveChanges();
        }
        */
        var now = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        /*
                var records = srv.GetDailyTimetable(now);

                using (var context = new SQLContext(this._configuration))
                {
                    var q = from a in context.THSRs
                            where a.Memo == now
                            select a;
                    if (q.Any() == false)
                    {
                        context.THSRs.AddRange(records);
                        context.SaveChanges();
                    }

                }*/


        Environment.Exit(0);
    }
}
