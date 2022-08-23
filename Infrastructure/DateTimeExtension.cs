using System;
using System.Globalization;

namespace Opendata.Infrastructure
{
    public static class DateTimeExtension
    {
        public static DateTime? ToDateTime(this string value, string format)
        {
            DateTime dt;
            if (DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out dt))
            {
                return dt;
            }
            return null;

        }
    }
}