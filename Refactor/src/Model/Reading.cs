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

        private DateTime date;
        private int amount;
    }
}