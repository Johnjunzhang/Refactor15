using System;

namespace Refactor.Model
{
    public class Reading
    {
        public int Amount()
        {
            return amount;
        }

        public DateTime Date()
        {
            return date;
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