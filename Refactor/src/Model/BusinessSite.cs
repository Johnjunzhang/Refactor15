using System;
using Refactor.Utils;

namespace Refactor.Model
{
    public class BusinessSite
    {
        private Reading[] readings = new Reading[1000];
        private static readonly double START_RATE = 0.09;
        private static double END_RATE = 0.05;
        private static int END_AMOUNT = 1000;

        public void addReading(Reading newReading)
        {
            readings[++lastReading] = newReading;
        }

        private int lastReading;

        public Dollars Charge()
        {
            int usage = readings[lastReading].Amount() - readings[lastReading - 1].Amount();
            return Charge(usage);
        }

        private Dollars Charge(int usage)
        {
            Dollars result;
            if (usage == 0) return new Dollars(0);
            double t1 = START_RATE - ((END_RATE*END_AMOUNT) - START_RATE)/(END_AMOUNT - 1);
            double t2 = ((END_RATE*END_AMOUNT) - START_RATE)*Math.Min(END_AMOUNT, usage)/
                (END_AMOUNT - 1);
            double t3 = Math.Max(usage - END_AMOUNT, 0)*END_RATE;
            result = new Dollars(t1 + t2 + t3);
            result = result.Plus(new Dollars(usage*0.0175));
            Dollars base1 = new Dollars(result.Min(new Dollars(50)).Times(0.07));
            if (result.IsGreaterThan(new Dollars(50)))
            {
                base1 = new Dollars(base1.Plus(result.Min(new Dollars(75)).Minus(
                    new Dollars(50)).Times(0.06)
                    ));
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