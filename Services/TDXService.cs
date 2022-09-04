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
            try
            {
                var sb = new StringBuilder();
                var token = await this.getTDXToken();
                // 取得高鐵每日時刻表所有供應的日期資料
                var url = "https://tdx.transportdata.tw/api/basic/v2/Rail/THSR/DailyTimetable/TrainDates";
                var timetables = await this.GetAsync<Timetables>(url, token.access_token);
                sb.AppendLine();
                foreach (var item in timetables.TrainDates)
                {
                    var tmpDt = item.ToDateTime("yyyy-MM-dd");
                    if (tmpDt == null)
                    {
                        continue;
                    }
                    if (tmpDt < DateTime.Now.Min())
                    {
                        continue;
                    }

                    var dailys = await this.getDailyTimetable(token.access_token, item);
                    //sb.AppendFormat("<p>轉檔日期：{0}, 車次筆數：{1}</p>", item, dailys.Count());
                    // 寫入資料庫
                    var isSet = this.setTHSRs(dailys, item);
                    // 失敗
                    if (isSet == true)
                    {
                        
                        sb.AppendFormat("<p>轉檔日期：{0}, 車次筆數：{1}</p>", item, dailys.Count());
                    }
                    else
                    {
                        sb.AppendLine($"<p>轉檔日期：{item}, 不需轉檔</p>");
                    }
                }
                // 寫入紀錄
                await this.SendEmail(sb.ToString());
            }
            catch (ExceptionFilter e)
            {
                string msg = $"方法: {e.MethName} 訊息: {e.Message}";
                await this.SendEmail(msg);
            }
            catch (ArgumentOutOfRangeException)
            {
                string msg = "方法: HandleDailyTimetable 訊息: 引數值超出例外狀況";
                await this.SendEmail(msg);
                //await this.Waring("方法: HandleDailyTimetable 訊息: 引數值超出例外狀況");
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
                catch (Exception ex)
                {
                    throw new ExceptionFilter("GetAsync", ex);
                }
            }
        }
        /// <summary>
        /// 取得指定[日期]所有車次的車次資料
        /// </summary>
        /// <param name="token"></param>
        /// <param name="trainDate"></param>
        /// <returns></returns>
        private async Task<IEnumerable<THSR>> getDailyTimetable(string token, string trainDate)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://tdx.transportdata.tw/api/basic/v2/Rail/THSR/DailyTimetable/TrainDate/" + trainDate;
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
                    ModifyUser = 0,
                });
            }
        }
        /// <summary>
        /// 設定車次資料
        /// </summary>
        /// <param name="records"></param>
        /// <param name="trainDate"></param>
        /// <returns></returns>
        private bool setTHSRs(IEnumerable<THSR> records, string trainDate)
        {
            using (var context = new SQLContext(this._configuration))
            {
                try
                {
                   
                    int eCode = 0;
                    var q = from a in context.THSRs
                            where a.Memo == trainDate
                            select a;
                    if (q.Any() == false)
                    {
                        context.THSRs.AddRange(records);
                        eCode = context.SaveChanges();
                    }
                    return eCode > 0 ? true : false;
                }
                catch (Microsoft.Data.SqlClient.SqlException ex)
                {
                    throw new ExceptionFilter("資料庫寫入異常", ex);
                }
            }
        }
    }
}