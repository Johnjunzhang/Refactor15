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
            var base1 = Math.Min(usage, 100)*0.03;
            if (usage > 100)
            {
                base1 += (Math.Min(usage, 200) - 100)*0.05;
            }
            if (usage > 200)
            {
                base1 += (usage - 200)*0.07;
            }
            var result = new Dollars(base1);
            var tax = new Dollars(result.Minus(new Dollars(8)).Max(new Dollars(0)).Times(TAX_RATE));
            result = result.Plus(tax);
            var fuelCharge = new Dollars(usage*0.0175);
            result = result.Plus(fuelCharge);
            return result.Plus(new Dollars(fuelCharge.Times(TAX_RATE)));
        }
    }
}