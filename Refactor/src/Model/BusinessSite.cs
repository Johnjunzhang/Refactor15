using System;
using Refactor.Common;
using Refactor.Model.Base;

namespace Refactor.Model
{
    public class Business : ChargeByUsageSite
    {
        private const double START_RATE = 0.09;
        private const double END_RATE = 0.05;
        private const int END_AMOUNT = 1000;

        protected override Dollars Charge(int usage)
        {
            if (usage == 0) return new Dollars(0);
            const double t1 = START_RATE - ((END_RATE*END_AMOUNT) - START_RATE)/(END_AMOUNT - 1);
            var t2 = ((END_RATE*END_AMOUNT) - START_RATE)*Math.Min(END_AMOUNT, usage)/(END_AMOUNT - 1);
            var t3 = Math.Max(usage - END_AMOUNT, 0)*END_RATE;
            var result = new Dollars(t1 + t2 + t3);
            result = result.Plus(new Dollars(usage*0.0175));
            var base1 = new Dollars(result.Min(new Dollars(50)).Times(0.07));
            if (result.IsGreaterThan(new Dollars(50)))
            {
                base1 = new Dollars(base1.Plus(result.Min(new Dollars(75)).Minus(new Dollars(50)).Times(0.06)));
            }
            if (result.IsGreaterThan(new Dollars(75)))
            {
                base1 = new Dollars(base1.Plus(result.Minus(new Dollars(75)).Times(0.05)));
            }
            result = result.Plus(base1);
            return result;
        }
    }
}