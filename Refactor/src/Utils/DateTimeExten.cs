using System;

namespace Refactor.Utils
{
    public static class DateTimeExten
    {
        public static bool Before(this DateTime datetime, DateTime target)
        {
            throw new NotImplementedException();
        }

        public static bool After(this DateTime datetime, DateTime target)
        {
            throw new NotImplementedException();
        }

        public static void SetDate(this DateTime datetime, int date)
        {
            throw new NotImplementedException();
        }

        public static int GetDate(this DateTime datetime)
        {
            return datetime.Day;
        }
    }
}