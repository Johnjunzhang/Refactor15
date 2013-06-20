using System;
using Refactor.Utils;

namespace Refactor.Model
{
    public class LifelineSite
    {
        private Reading[] readings = new Reading[1000];
        private static readonly double TAX_RATE = 0.05;

        public void addReading(Reading newReading)
        {
            Reading[] newArray = new Reading[readings.Length + 1];
            Array.Copy(readings, 0, newArray, 1, readings.Length);
            newArray[0] = newReading;
            readings = newArray;
        }

        public Dollars Charge()
        {
            int usage = readings[0].Amount() - readings[1].Amount();
            return Charge(usage);
        }

        private Dollars Charge(int usage)
        {
            double base1 = Math.Min(usage, 100)*0.03;
            if (usage > 100)
            {
                base1 += (Math.Min(usage, 200) - 100)*0.05;
            }
            if (usage > 200)
            {
                base1 += (usage - 200)*0.07;
            }
            Dollars result = new Dollars(base1);
            Dollars tax = new Dollars(result.Minus(new Dollars(8)).Max(new Dollars(0)).Times(TAX_RATE));
            result = result.Plus(tax);
            Dollars fuelCharge = new Dollars(usage*0.0175);
            result = result.Plus(fuelCharge);
            return result.Plus(new Dollars(fuelCharge.Times(TAX_RATE)));
        }
    }
}