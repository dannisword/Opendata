using System.Text.Json;

namespace Opendata.Infrastructure
{
    public class ExceptionFilter : Exception
    {
        public string MethName { get; set; }

        public override string Message { get;  }

        public ExceptionFilter(string methName, Exception ex)
        {
            this.MethName = methName;
            this.Message = this.getExceptionMessage(ex);
        }

        private string getExceptionMessage(Exception ex)
        {
            switch (ex)
            {
                case System.InvalidOperationException:
                    return "無效操作";
                case HttpRequestException:
                    return "HTTP 訊息處理例外狀況";
                case TaskCanceledException:
                    return "工作取消的例外狀況";
                case ArgumentNullException:
                    return "傳遞的引數例外狀況";
                case JsonException:
                    return "無效JSON";
                case NotSupportedException:
                    return "方法不受支援";
                default:
                    return "未攔截例外狀況";
            }
        }
    }
}