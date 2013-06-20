using System;
using Refactor.Common;
using Refactor.Model.Base;

namespace Refactor.Model
{
    public class Residential:ChargeByUsageAndStartEndSite
    {
        public Residential(Zone zone) : base(zone)
        {
        }

        protected override Dollars Charge(int usage, DateTime start, DateTime end)
        {
            double summerFraction;
            // Find out how much of period is in the summer
            if (start.After(zone.SummerEnd()) || end.Before(zone.SummerStart()))
                summerFraction = 0;
            else if (!start.Before(zone.SummerStart()) && !start.After(zone.SummerEnd()) && !end.Before(zone.SummerStart()) && !end.After(zone.SummerEnd()))
            {
                summerFraction = 1;
            }
            else
            {
                // part in summer part in winter
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
                
                summerFraction = summerDays/(end.DayOfYear - start.DayOfYear + 1);
            }
            var result = new Dollars((usage*zone.SummerRate()*summerFraction) + (usage*zone.WinterRate()*(1 - summerFraction)));
            result = result.Plus(new Dollars(result.Times(TAX_RATE)));
            var fuel = new Dollars(usage*0.0175);
            result = result.Plus(fuel);
            result = new Dollars(result.Plus(fuel.Times(TAX_RATE)));
            return result;
        }
    }
}