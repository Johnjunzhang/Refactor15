using System;

namespace Refactor.Utils
{
    public static class DateTimeExten
    {
        public static bool Before(this DateTime datetime, DateTime target)
        {
            return datetime.CompareTo(target) < 0;
        }

        public static bool After(this DateTime datetime, DateTime target)
        {
            return datetime.CompareTo(target) > 0;
        }

        public static DateTime SetDate(this DateTime datetime, int date)
        {
            return new DateTime(datetime.Year, datetime.Month, date);
        }

        public static int GetDate(this DateTime datetime)
        {
            return datetime.Day;
        }
    }
}