using System;

namespace Refactor
{
    public class ResidentialSite
    {
        private Zone zone;
        private Reading[] readings = new Reading[1000];
        private const double TAX_RATE = 0.05;

        public ResidentialSite(Zone zone)
        {
            this.zone = zone;
        }

        public void AddReading(Reading newReading)
        {
            // add reading to end of array
            int i = 0;
            while (readings[i] != null) i++;
            readings[i] = newReading;
        }

        public Dollars Charge()
        {
            // find last reading
            int i = 0;
            while (readings[i] != null) i++;
            int usage = readings[i - 1].Amount() - readings[i - 2].Amount();
            DateTime end = readings[i - 1].Date();
            DateTime start = readings[i - 2].Date();
            start.SetDate(start.GetDate() + 1); //set to begining of period
            return Charge(usage, start, end);
        }

        private Dollars Charge(int usage, DateTime start, DateTime end)
        {
            Dollars result;
            double summerFraction;
            // Find out how much of period is in the summer
            if (start.After(zone.SummerEnd()) || end.Before(zone.SummerStart()))
                summerFraction = 0;
            else if (!start.Before(zone.SummerStart()) && !start.After(zone.SummerEnd()) &&
                !end.Before(zone.SummerStart()) && !end.After(zone.SummerEnd()))
                summerFraction = 1;
            else
            {
                // part in summer part in winter
                double summerDays;
                if (start.Before(zone.SummerStart()) || start.After(zone.SummerEnd()))
                {
                    // end is in the summer
                    summerDays = DayOfYear(end) - DayOfYear(zone.SummerStart()) + 1;
                }
                else
                {
                    // start is in summer
                    summerDays = DayOfYear(zone.SummerEnd()) - DayOfYear(start) + 1;
                }
                ;
                summerFraction = summerDays/(DayOfYear(end) - DayOfYear(start) + 1);
            }
            ;
            result = new Dollars((usage*zone.SummerRate()*summerFraction) + (usage*zone.WinterRate()*(1 - summerFraction)));
            result = result.Plus(new Dollars(result.Times(TAX_RATE)));
            Dollars fuel = new Dollars(usage*0.0175);
            result = result.Plus(fuel);
            result = new Dollars(result.Plus(fuel.Times(TAX_RATE)));
            return result;
        }

        private int DayOfYear(DateTime arg)
        {
            int result;
            switch (arg.Month)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = 31;
                    break;
                case 2:
                    result = 59;
                    break;
                case 3:
                    result = 90;
                    break;
                case 4:
                    result = 120;
                    break;
                case 5:
                    result = 151;
                    break;
                case 6:
                    result = 181;
                    break;
                case 7:
                    result = 212;
                    break;
                case 8:
                    result = 243;
                    break;
                case 9:
                    result = 273;
                    break;
                case 10:
                    result = 304;
                    break;
                case 11:
                    result = 334;
                    break;
                default:
                    throw new ArgumentException();
            }
            result += arg.GetDate();
            //check leap year
            if ((arg.Year%4 == 0) && ((arg.Year%100 != 0) ||
                ((arg.Year + 1900)%400 == 0)))
            {
                result++;
            }
            return result;
        }
    }

    public static class DateTimeExten
    {
        public static bool Before(this DateTime datetime, DateTime target)
        {
            throw new NotImplementedException();
        }

        public static bool After(this DateTime datetime, DateTime target)
        {
            throw new NotImplementedException();
        }

        public static void SetDate(this DateTime datetime, int date)
        {
            throw new NotImplementedException();
        }

        public static int GetDate(this DateTime datetime)
        {
            return datetime.Day;
        }
    }

    public class Dollars
    {
        public double Amount { get; set; }

        public Dollars(double d)
        {
            Amount = d;
        }

        public Dollars Plus(Dollars dollars)
        {
            return new Dollars(Amount + dollars.Amount);
        }

        public double Plus(double dollars)
        {
            return Amount + dollars;
        }

        public double Times(double taxRate)
        {
            throw new NotImplementedException();
        }
    }

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

    public class Zone
    {
        public DateTime SummerEnd()
        {
            return summerEnd;
        }

        public DateTime SummerStart()
        {
            return summerStart;
        }

        public double SummerRate()
        {
            return summerRate;
        }

        public double WinterRate()
        {
            return winterRate;
        }

        public Zone(double WinterRate, double SummerRate, DateTime SummerStart, DateTime SummerEnd)
        {
            this.winterRate = WinterRate;
            this.summerRate = SummerRate;
            this.summerStart = SummerStart;
            this.summerEnd = SummerEnd;
        }

        private DateTime summerEnd;

        private DateTime summerStart;
        private double summerRate;
        private double winterRate;
    }
}