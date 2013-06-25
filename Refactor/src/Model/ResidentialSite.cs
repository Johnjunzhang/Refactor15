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
            var summerFraction = GetSummerFraction(start,end);
            var result = new Dollars((usage*zone.SummerRate()*summerFraction) + (usage*zone.WinterRate()*(1 - summerFraction)));
            var fuel = new Dollars(usage*0.0175);
            return new Dollars(result.Plus(new Dollars(result.Times(TAX_RATE))).Plus(fuel).Plus(fuel.Times(TAX_RATE)));
        }
    }
}