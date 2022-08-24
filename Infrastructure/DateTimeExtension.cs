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

        public static DateTime Min(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);
        }
    }
}