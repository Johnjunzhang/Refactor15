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
            var usage = Math.Min(fullUsage, CAP);
            var summerCharge = (usage*zone.SummerRate()*GetSummerFraction(start, end));
            var winterCharge = (usage*zone.WinterRate()*(1 - GetSummerFraction(start, end)));
            var other = Math.Max(fullUsage - usage, 0)*0.062;
            var fuel = new Dollars(fullUsage*0.0175);
            var baseCount = new Dollars(summerCharge + winterCharge + other);
            return new Dollars(baseCount.Plus(new Dollars(baseCount.Times(TAX_RATE))).Plus(fuel).Plus(fuel.Times(TAX_RATE).Min(FUEL_TAX_CAP)));
        }
    }
}