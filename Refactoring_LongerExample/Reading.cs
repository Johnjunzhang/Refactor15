using System;

namespace Refactoring_LongerExample
{
    public class Reading
    {
        public DateTime Date()
        {
            return date;
        }

        public int Amount()
        {
            return amount;
        }

        public Reading(int amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }

        private readonly DateTime date;
        private readonly int amount;
    }
}