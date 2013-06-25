using System;
using Refactor.Common;
using Refactor.Model.Base;

namespace Refactor.Model
{
    public class LifelineSite:ChargeByUsageSite
    {
        private const double TAX_RATE = 0.05;

        protected override Dollars Charge(int usage)
        {
            var baseCount = GetBaseCount(usage);
            var fuel = new Dollars(usage*0.0175);
            return new Dollars(baseCount).Plus(new Dollars(new Dollars(baseCount).Minus(new Dollars(8)).Max(new Dollars(0)).Times(TAX_RATE))).Plus(fuel).Plus(new Dollars(fuel.Times(TAX_RATE)));
        }

        private double GetBaseCount(int usage)
        {
            var baseCount = Math.Min(usage, 100)*0.03;
            if (usage > 100)
            {
                baseCount += (Math.Min(usage, 200) - 100)*0.05;
            }
            if (usage > 200)
            {
                baseCount += (usage - 200)*0.07;
            }
            return baseCount;
        }
    }
}