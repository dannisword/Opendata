using System;
using System.Collections;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

using Opendata.Models;
using Opendata.Entities;
using Opendata.Infrastructure;

namespace Opendata.Services
{
    /// 高鐵
    public class TDXService : DefaultServices, ITDXService
    {
        private readonly ILogger<TDXService> _logger;
        private readonly IConfiguration _configuration;

        public TDXService(
            ILogger<TDXService> logger,
            IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task HandleDailyTimetable()
        {
            var url = "https://tdx.transportdata.tw/api/basic/v2/Rail/THSR/DailyTimetable/TrainDates";
            try
            {
                var sb = new StringBuilder();
                var tdx = await this.getTDXToken();
                var timetables = await this.GetAsync<Timetables>(url, tdx.access_token);
                sb.AppendLine();
                foreach (var item in timetables.TrainDates)
                {
                    var dailys = await this.getDailyTimetable(tdx.access_token, item);
                    var content = $"轉檔日期：{item}, 車次筆數：{dailys.Count()}";
                    sb.AppendLine(content);
                }
                await this.Success(sb.ToString());
            }
            catch (Exception e)
            {
                await this.Waring(e.Message);
            }
        }
        /// <summary>
        /// 取得 Token
        /// </summary>
        /// <returns></returns>
        private async Task<AccessToken> getTDXToken()
        {
            string baseUrl = "https://tdx.transportdata.tw/auth/realms/TDXConnect/protocol/openid-connect/token";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpContent formData = new FormUrlEncodedContent(
                        new List<KeyValuePair<string, string>>
                            {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id", "dannis.word-4a3a5894-c2a5-4ce0"),
                            new KeyValuePair<string, string>("client_secret", "5058c0b6-32a1-4f92-9072-e17eb5bb1fee"),
                            }
                        );
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    var response = await httpClient.PostAsync(baseUrl, formData);
                    var responseStr = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<AccessToken>(responseStr);
                }
                catch (InvalidOperationException)
                {
                    throw new Exception($"GetTDXToken: {Constants.INVAILD_OPERATION_EXCEPTION}");
                }
                catch (HttpRequestException)
                {
                    throw new Exception($"GetTDXToken: {Constants.HTTP_REQUEST_EXCEPTION}");
                }
                catch (TaskCanceledException)
                {
                    throw new Exception($"GetTDXToken: {Constants.TASK_CANCEL_EXCEPTION}");
                }
                catch (ArgumentNullException)
                {
                    throw new Exception($"GetTDXToken: {Constants.ARGUMENT_NULL_EXCEPTION}");
                }
                catch (JsonException)
                {
                    throw new Exception($"GetTDXToken: {Constants.JSON_EXCEPTION}");
                }
                catch (NotSupportedException)
                {
                    throw new Exception($"GetTDXToken: {Constants.NOT_SUPPORTED_EXCEPTION}");
                }
            }
        }

        private async Task<IEnumerable<THSR>> getDailyTimetable(string token, string trainDate)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"https://tdx.transportdata.tw/api/basic/v2/Rail/THSR/DailyTimetable/TrainDate/{trainDate}";
                var dailys = await this.GetAsyncs<DailyTimetable>(url, token);
                return dailys.Select(x => new THSR()
                {
                    Direction = x.DailyTrainInfo.Direction == 0 ? (byte)2 : x.DailyTrainInfo.Direction,
                    CarNo = x.DailyTrainInfo.TrainNo,
                    StartStationName = x.DailyTrainInfo.StartingStationName.Zh_tw,
                    DepartureTime = x.StopTimes.First().DepartureTime,
                    EndingStationName = x.DailyTrainInfo.EndingStationName.Zh_tw,
                    ArrivalTime = x.StopTimes.Last().ArrivalTime,
                    Memo = x.TrainDate,
                    CreateTime = DateTime.Now,
                    CreateUser = 0,
                    ModifyTime = DateTime.Now,
                    ModifyUser = 0
                });
            }
        }
        private async Task<bool> set()
        {
            using (var context = new SQLContext(this._configuration))
            {
                /*
                var q = from a in context.THSRs
                        where a.Memo == now
                        select a;
                if (q.Any() == false)
                {
                    context.THSRs.AddRange(records);
                    context.SaveChanges();
                }*/

            }
            return false;
        }
    }
}