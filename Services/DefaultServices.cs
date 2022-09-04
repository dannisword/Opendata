using System.Text.Json;
using System.Net.Http.Headers;

using Opendata.Models;
using Opendata.Infrastructure;

namespace Opendata.Services
{
    public class DefaultServices
    {
        public async Task<T> GetAsync<T>(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    if (string.IsNullOrEmpty(token) == false)
                    {
                        client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                    }
                    var response = await client.GetStringAsync(url);
                    return JsonSerializer.Deserialize<T>(response);
                }
                catch (Exception ex)
                {
                    throw new ExceptionFilter("GetAsync", ex);
                }
            }
        }

        public async Task<IEnumerable<T>> GetAsyncs<T>(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (string.IsNullOrEmpty(token) == false)
                    {
                        client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                    }
                    var response = await client.GetStringAsync(url);
                    return JsonSerializer.Deserialize<IEnumerable<T>>(response);
                }
                catch (Exception ex)
                {
                    throw new ExceptionFilter("GetAsyncs", ex);
                }
            }
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

        public async Task SendEmail(string content)
        {
            string subject = string.Format("{0}轉檔", DateTime.Now.ToString("yyyy-MM-dd"));
            await new EmailSender().SendAsync("dannis.word@gmail.com", subject, content);
            //
        }
        public async Task Success(string content)
        {
            await this.WriteLineAsync(LogType.Success, content);
        }

        public async Task Waring(string content)
        {
            await this.WriteLineAsync(LogType.Waring, content);
        }

        private async Task WriteLineAsync(LogType logType, string content)
        {
            var fileName = string.Format("{0}.log", DateTime.Now.ToString("yyyyMMdd"));
            var typeName = "訊息";
            if (logType == LogType.Waring)
            {
                typeName = "警告";
            }
            var msg = string.Format("[{0}] - {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), typeName, content);

            using (StreamWriter file = new(fileName, append: true))
            {
                await file.WriteLineAsync(msg);
            }
        }
    }
}