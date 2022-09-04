using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

using Opendata.Models;
using Opendata.Entities;
using Opendata.Infrastructure;

namespace Opendata.Services
{
    // 裁決書
    public class OpendataService : DefaultServices, IOpendataService
    {
        private readonly ILogger<IOpendataService> _logger;
        private readonly IConfiguration _configuration;
        public OpendataService(ILogger<IOpendataService> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
        }
        /// <summary>
        /// 裁
        /// </summary>
        /// <returns></returns>
        public async Task GetJDocs2()
        {
            var token = this.getToken();
            var url = "https://data.judicial.gov.tw/jdg/api/JList";
            var result = this.PostRequest(url, token);
            var e = result.Contains("error");
            await this.Waring(result);
            if (e == true)
            {
                return;
            }
            var jList = JsonSerializer.Deserialize<List<JList>>(result);
            var source = jList[0].list;
            this.setJUList(jList[0]);
            var docs = new List<JUDoc>();
            foreach (var item in source)
            {
                url = "https://data.judicial.gov.tw/jdg/api/JDoc";
                var p = new JParam()
                {
                    Token = token.Token,
                    J = item
                };
                var data = this.PostRequest(url, p);
                try
                {
                    e = data.Contains("error");
                    await this.Waring($"{item} - {data}");
                    if (e == true)
                    {
                        continue;
                    }
                    var jDoc = JsonSerializer.Deserialize<JDoc>(data);
                    if (jDoc.JID != null)
                    {
                        var doc = new JUDoc()
                        {
                            Attachments = jDoc.ATTACHMENTS == null ? "" : JsonSerializer.Serialize(jDoc.ATTACHMENTS),
                            JID = jDoc.JID,
                            JFullX = JsonSerializer.Serialize(jDoc.JFULLX),
                            JYear = jDoc.JYEAR,
                            JCase = jDoc.JCASE,
                            JNO = jDoc.JNO,
                            JDate = jDoc.JDATE,
                            JTitle = jDoc.JTITLE,
                            CreateTime = DateTime.Now,
                            CreateUser = 0,
                            ModifyTime = DateTime.Now,
                            ModifyUser = 0
                        };
                        this._logger.LogInformation(doc.JID);
                        using (var db = new SQLContext(this._configuration))
                        {
                            db.JDocs.Add(doc);
                            db.SaveChanges();
                        }
                        docs.Add(doc);
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    //this._logger.LogWarning(ex.Message);
                    await this.Waring(ex.Message);
                }
            }

            this.setJUDocs(docs);
            // 新增資料庫
        }
        public async Task GetJDocs()
        {
            await this.Success($"裁決書開始下載");
            StringBuilder sb = new StringBuilder();

            var token = this.getToken();
            var url = "https://data.judicial.gov.tw/jdg/api/JList";
            var result = this.PostRequest(url, token);
            var jList = JsonSerializer.Deserialize<List<JList>>(result);
            var source = jList[0].list;
            var courts = new List<CourtVerdict>();
            var count = 0;
            foreach (var item in source)
            {
                //
                count++;
                var ids = item.Split(',');
                var year = int.Parse(ids[1]);
                if (year != (DateTime.Now.Year - 1911))
                {
                    continue;
                }
                url = "https://data.judicial.gov.tw/jdg/api/JDoc";

                var p = new JParam()
                {
                    Token = token.Token,
                    J = item
                };

                var data = this.PostRequest(url, p);
                var jDoc = JsonSerializer.Deserialize<JDoc>(data);
                var court = new CourtVerdict()
                {
                    JID = jDoc.JID,
                    JYear = jDoc.JYEAR,
                    JNo = jDoc.JNO,
                    JDate = jDoc.JDATE,
                    JCase = jDoc.JCASE,
                    JTitle = jDoc.JTITLE,
                    CreateTime = DateTime.Now,
                    CreateUser = 0,
                    ModifyTime = DateTime.Now,
                    ModifyUser = 0
                };
                //System.Diagnostics.Debug.WriteLine($"{count}: {item}");
                this._logger.LogInformation($"{count}: {item}");
                courts.Add(court);
            }
            await this.Success($"裁決書總下載筆數{courts.Count()}");
            this.setCourtVerdict(courts);
        }
        private OpendataToken getToken()
        {
            var url = "https://data.judicial.gov.tw/jdg/api/Auth";

            var auth = new Auth()
            {
                user = "dannis",
                password = "Qwer890@"
            };
            var result = this.PostRequest(url, auth);
            var token = JsonSerializer.Deserialize<OpendataToken>(result);
            return token;
        }

        private bool setJUDocs(IEnumerable<JUDoc> data)
        {
            using (var db = new SQLContext(this._configuration))
            {
                db.JDocs.AddRange(data);
                return db.SaveChanges() > 0 ? true : false;
            }
        }
        private bool setJUList(JList data)
        {
            using (var db = new SQLContext(this._configuration))
            {
                var jList = new List<JUList>();
                var q = from a in db.JLists
                        where a.ListDate == data.date
                        select a;
                if (q.Any())
                {
                    return false;
                }
                foreach (var item in data.list)
                {
                    JUList list = new JUList()
                    {
                        ListDate = data.date,
                        ListItem = item,
                        CreateTime = DateTime.Now,
                        CreateUser = 0,
                        ModifyTime = DateTime.Now,
                        ModifyUser = 0
                    };
                    jList.Add(list);
                }
                db.JLists.AddRange(jList);
                return db.SaveChanges() > 0 ? true : false;
            }
        }
        private bool setCourtVerdict(IEnumerable<CourtVerdict> records)
        {
            using (var context = new SQLContext(this._configuration))
            {
                var year = (DateTime.Now.Year - 1911);
                var q = from a in context.CourtVerdicts
                        where a.JYear == year.ToString()
                        select a;
                var docs = q.ToList();
                var courts = new List<CourtVerdict>();
                foreach (var record in records)
                {
                    if (record.JID == null)
                    {
                        continue;
                    }
                    var p = docs.Where(x => x.JID == record.JID);
                    if (p.Any() == false)
                    {
                        courts.Add(record);
                    }
                }
                try
                {
                    context.CourtVerdicts.AddRange(courts);
                    var count = context.SaveChanges();
                    this.Success($"裁決書異動筆數{count}");
                }
                catch (Microsoft.Data.SqlClient.SqlException)
                {
                    this.Waring("資料庫寫入異常");
                    return false;
                }

                return false;
            }
        }
    }
}