using System;
using System.Linq;

namespace GlowingEngine
{
    public class AgeQuantizedToTicks : IGetAgeSumIntersect
    {
        public DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            // general formula is (pYears - cYears) / nChildren - 1

            long pTicks = parent.Ticks;
            long cTicks = children.Sum(c => c.Ticks);

            long targetDateInTicks = (cTicks - pTicks) / (children.Length - 1);

            return new DateTime(targetDateInTicks);
        }
    }
}