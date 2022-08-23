using System.Text.Json;
using Opendata.Models;

namespace Opendata.Services
{
    public class DefaultServices
    {
        public async Task<T> GetAsync<T>(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                if (string.IsNullOrEmpty(token) == false)
                {
                    client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                }
                try
                {
                    var response = await client.GetStringAsync(url);
                    return JsonSerializer.Deserialize<T>(response);
                }
                catch (InvalidOperationException)
                {
                    throw new Exception($"GetAsync: {Constants.INVAILD_OPERATION_EXCEPTION}");
                }
                catch (HttpRequestException)
                {
                    throw new Exception($"GetAsync: {Constants.HTTP_REQUEST_EXCEPTION}");
                }
                catch (TaskCanceledException)
                {
                    throw new Exception($"GetAsync: {Constants.TASK_CANCEL_EXCEPTION}");
                }
                catch (ArgumentNullException)
                {
                    throw new Exception($"GetAsync: {Constants.ARGUMENT_NULL_EXCEPTION}");
                }
                catch (JsonException)
                {
                    throw new Exception($"GetAsync: {Constants.JSON_EXCEPTION}");
                }
                catch (NotSupportedException)
                {
                    throw new Exception($"GetAsync: {Constants.NOT_SUPPORTED_EXCEPTION}");
                }
            }
        }

        public async Task<IEnumerable<T>> GetAsyncs<T>(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                if (string.IsNullOrEmpty(token) == false)
                {
                    client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                }
                try
                {
                    var response = await client.GetStringAsync(url);
                    return JsonSerializer.Deserialize<IEnumerable<T>>(response);
                }
                catch (InvalidOperationException)
                {
                    throw new Exception($"GetAsyncs: {Constants.INVAILD_OPERATION_EXCEPTION}");
                }
                catch (HttpRequestException)
                {
                    throw new Exception($"GetAsyncs: {Constants.HTTP_REQUEST_EXCEPTION}");
                }
                catch (TaskCanceledException)
                {
                    throw new Exception($"GetAsyncs: {Constants.TASK_CANCEL_EXCEPTION}");
                }
                catch (ArgumentNullException)
                {
                    throw new Exception($"GetAsyncs: {Constants.ARGUMENT_NULL_EXCEPTION}");
                }
                catch (JsonException)
                {
                    throw new Exception($"GetAsyncs: {Constants.JSON_EXCEPTION}");
                }
                catch (NotSupportedException)
                {
                    throw new Exception($"GetAsyncs: {Constants.NOT_SUPPORTED_EXCEPTION}");
                }
            }
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