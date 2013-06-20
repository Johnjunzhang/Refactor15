using System;
using System.Globalization;

namespace Refactor.Utils
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
            Amount = times.Amount;
        }

        public Dollars Plus(Dollars dollars)
        {
            return new Dollars(Amount + dollars.Amount);
        }

        public Dollars Times(double taxRate)
        {
            return new Dollars(Amount*taxRate);
        }

        public Dollars Min(Dollars dollars)
        {
            return Amount <= dollars.Amount ? this : dollars;
        }

        public Dollars Minus(Dollars dollars)
        {
            return new Dollars(Amount - dollars.Amount);
        }

        public Dollars Max(Dollars dollars)
        {
            return Amount >= dollars.Amount ? this : dollars;
        }

        public bool IsGreaterThan(Dollars dollars)
        {
            return Amount > dollars.Amount;
        }

        protected bool Equals(Dollars other)
        {
            return Amount.ToString("0.00").Equals(other.Amount.ToString("0.00"));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Dollars) obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        public override string ToString()
        {
            return Amount.ToString("0.00");
        }
    }
}