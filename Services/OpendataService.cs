using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

using Opendata.Models;
using Opendata.Entities;
using Opendata.Infrastructure;

namespace Opendata.Services
{

    // 裁決書
    public class OpendataService
    {

        public OpendataToken GetOpendataToken()
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

        public List<CourtVerdict> GetJDocs(OpendataToken token)
        {
            var url = "https://data.judicial.gov.tw/jdg/api/JList";
            var result = this.PostRequest(url, token);
            var jList = JsonSerializer.Deserialize<List<JList>>(result);
            var source = jList[0].list;
            var courts = new List<CourtVerdict>();
            foreach (var item in source)
            {
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
                    //JDate = jDoc.JDATE.ToDateTime(),
                    JCase = jDoc.JCASE,
                    JTitle = jDoc.JTITLE,
                    CreateTime = DateTime.Now,
                    CreateUser = 0
                };
                System.Diagnostics.Debug.WriteLine(item);
                courts.Add(court);
            }

            return courts;
        }

        public string PostRequest(string url, object obj)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var buffer = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
                    var content = new ByteArrayContent(buffer);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync(url, content).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}