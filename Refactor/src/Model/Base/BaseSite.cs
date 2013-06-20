using System;
using Refactor.Common;

namespace Refactor.Model.Base
{
    public abstract class BaseSite
    {
        protected readonly Reading[] readings = new Reading[1000];

        public void AddReading(Reading newReading)
        {
            var i = 0;
            while (readings[i] != null) i++;
            readings[i] = newReading;
        }

        public abstract Dollars Charge();

        protected Reading GetOneBeforeLastReading()
        {
            return readings[LastIndex() - 2];
        }

        protected Reading GetLastReading()
        {
            return readings[LastIndex() - 1];
        }

        protected int LastIndex()
        {
            int i;
            for (i = 0; readings[i] != null; i++) ;
            return i;
        }

        protected int GetUsage()
        {
            return GetLastReading().Amount() - GetOneBeforeLastReading().Amount();
        }

        protected DateTime GetLastReadingStartDate()
        {
            return GetOneBeforeLastReading().Date().AddDays(1);
        }

        protected DateTime GetLastReadingEndDate()
        {
            return GetLastReading().Date();
        }
    }
}