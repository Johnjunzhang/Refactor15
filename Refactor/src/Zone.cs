using System;

namespace Refactor
{
    public class Zone
    {
        public DateTime SummerEnd()
        {
            return summerEnd;
        }

        public DateTime SummerStart()
        {
            return summerStart;
        }

        public double SummerRate()
        {
            return summerRate;
        }

        public double WinterRate()
        {
            return winterRate;
        }

        public Zone(string rate, double WinterRate, double SummerRate, DateTime SummerStart, DateTime SummerEnd)
        {
            this.winterRate = WinterRate;
            this.summerRate = SummerRate;
            this.summerStart = SummerStart;
            this.summerEnd = SummerEnd;
        }

        private DateTime summerEnd;

        private DateTime summerStart;
        private double summerRate;
        private double winterRate;
    }
}