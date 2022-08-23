namespace Opendata.Models
{
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 10,
        /// <summary>
        /// 查無資料
        /// </summary>
        NotFound = 20,
        /// <summary>
        /// 失敗
        /// </summary>
        Failed = 90,
        /// <summary>
        /// Exception
        /// </summary>
        Exception = 99
    }

    public class ResultData
    {
        public int StatusCode { get; set; }
        
        public ResultCode ResultCode { get; set; }

        public string Message { get; set; }

        public dynamic Value { get; set; }

        public IEnumerable<dynamic> Source { get; set; }
        public ResultData()
        {

        }
        public ResultData(dynamic value)
        {
            this.Value = value;
            this.ResultCode = ResultCode.Success;
        }
        public ResultData(ResultCode resultCode, string message)
        {
            this.ResultCode = resultCode;
            this.Message = message;
        }

        public ResultData(IEnumerable<dynamic> source)
        {
            if (source == null)
            {
                this.ResultCode = ResultCode.NotFound;
                this.Message = "無查詢資料";
            }
            else
            {
                this.ResultCode = ResultCode.Success;
                this.Source = source;
            }
        }
    }
}