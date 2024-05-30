using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Utils
{
    public static class FormateDate
    {
        public static string ClientFormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static DateTime? ServerFormatDate(string dateStr, string format = "yyyy-MM-dd")
        {
            if (string.IsNullOrEmpty(dateStr))
            {
                return null; // Or set a default value based on your schema
            }

            DateTime dt;
            if (DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return dt;
            }
            else
            {
                throw new ArgumentException($"Invalid date format. Please use {format}.");
            }
        }
    }
}
