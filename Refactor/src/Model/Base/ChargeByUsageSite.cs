using Refactor.Common;

namespace Refactor.Model.Base
{
    public abstract class ChargeByUsageSite : BaseSite
    {
        public override Dollars Charge()
        {
            return Charge(GetUsage());
        }

        protected abstract Dollars Charge(int usage);
    }
}