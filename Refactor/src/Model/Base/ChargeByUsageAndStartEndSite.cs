using System;
using Refactor.Common;

namespace Refactor.Model.Base
{
    public abstract class ChargeByUsageAndStartEndSite : BaseSite
    {
        protected const double TAX_RATE = 0.05;
        protected Zone zone;

        protected ChargeByUsageAndStartEndSite(Zone zone)
        {
            this.zone = zone;
        }

        public override Dollars Charge()
        {
            return Charge(GetUsage(), GetLastReadingStartDate(), GetLastReadingEndDate());
        }

        protected abstract Dollars Charge(int usage, DateTime start, DateTime end);
    }
}