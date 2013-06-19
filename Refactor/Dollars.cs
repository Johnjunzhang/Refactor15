using System;

namespace Refactor
{
    public class Dollars
    {
        public double Amount { get; set; }

        public Dollars(double d)
        {
            Amount = d;
        }

        public Dollars(Dollars times)
        {
            this.Amount = times.Amount;
        }

        public Dollars Plus(Dollars dollars)
        {
            return new Dollars(Amount + dollars.Amount);
        }

        public Dollars Times(double taxRate)
        {
            throw new NotImplementedException();
        }

        public Dollars Min(Dollars fuelTaxCap)
        {
            throw new NotImplementedException();
        }

        public Dollars Minus(Dollars dollars)
        {
            throw new NotImplementedException();
        }

        public Dollars Max(Dollars dollars)
        {
            throw new NotImplementedException();
        }

        public bool IsGreaterThan(Dollars dollars)
        {
            throw new NotImplementedException();
        }
    }
}