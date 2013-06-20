using System;
using Refactor.Common;
using Refactor.Model.Base;

namespace Refactor.Model
{
    public class Disability : ChargeByUsageAndStartEndSite
    {
        private static readonly Dollars FUEL_TAX_CAP = new Dollars(0.10);

        private const int CAP = 200;

        public Disability(Zone zone) : base(zone)
        {
        }

        protected override Dollars Charge(int fullUsage, DateTime start, DateTime end)
        {
            double summerFraction;
            var usage = Math.Min(fullUsage, CAP);
            if (start.After(zone.SummerEnd()) || end.Before(zone.SummerStart()))
                summerFraction = 0;
            else if (!start.Before(zone.SummerStart()) && !start.After(zone.SummerEnd()) &&
                !end.Before(zone.SummerStart()) && !end.After(zone.SummerEnd()))
                summerFraction = 1;
            else
            {
                double summerDays;
                if (start.Before(zone.SummerStart()) || start.After(zone.SummerEnd()))
                {
                    // end is in the summer
                    summerDays = end.DayOfYear - zone.SummerStart().DayOfYear + 1;
                }
                else
                {
                    // start is in summer
                    summerDays = zone.SummerEnd().DayOfYear - start.DayOfYear + 1;
                }
                ;
                summerFraction = summerDays/(end.DayOfYear - start.DayOfYear + 1);
            }
            var result = new Dollars((usage*zone.SummerRate()*summerFraction) +
                (usage*zone.WinterRate()*(1 - summerFraction)));
            result = result.Plus(new Dollars(Math.Max(fullUsage - usage, 0)*0.062));
            result = result.Plus(new Dollars(result.Times(TAX_RATE)));
            var fuel = new Dollars(fullUsage*0.0175);
            result = result.Plus(fuel);
            result = new Dollars(result.Plus(fuel.Times(TAX_RATE).Min(FUEL_TAX_CAP)));
            return result;
        }
    }
}