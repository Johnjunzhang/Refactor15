using System;
using Refactor.Common;

namespace Refactor.Model.Base
{
    public abstract class ChargeByUsageAndStartEndSite : BaseSite
    {
        protected const double TAX_RATE = 0.05;
        protected Zone zone;

        protected ChargeByUsageAndStartEndSite(Zone zone)
        {
            this.zone = zone;
        }

        public override Dollars Charge()
        {
            return Charge(GetUsage(), GetLastReadingStartDate(), GetLastReadingEndDate());
        }

        protected abstract Dollars Charge(int usage, DateTime start, DateTime end);

        protected double GetSummerFraction(DateTime start, DateTime end)
        {
            if (NotInSummer(start, end))
                return  0;
            if (AllInSummer(start, end))
                return 1;
            return GetSummerDays(start, end)/(end.DayOfYear - start.DayOfYear + 1);
        }

        private double GetSummerDays(DateTime start, DateTime end)
        {
            if (NotStartInSummer(start))
            {
                return end.DayOfYear - zone.SummerStart().DayOfYear + 1;
            }
            return zone.SummerEnd().DayOfYear - start.DayOfYear + 1;
        }

        private bool NotStartInSummer(DateTime start)
        {
            return start.Before(zone.SummerStart()) || start.After(zone.SummerEnd());
        }

        private bool AllInSummer(DateTime start, DateTime end)
        {
            return !start.Before(zone.SummerStart()) && !start.After(zone.SummerEnd()) &&
                   !end.Before(zone.SummerStart()) && !end.After(zone.SummerEnd());
        }

        private bool NotInSummer(DateTime start, DateTime end)
        {
            return start.After(zone.SummerEnd()) || end.Before(zone.SummerStart());
        }
    }
}