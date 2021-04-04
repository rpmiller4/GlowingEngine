using System;
using System.Linq;

namespace GlowingEngine
{
    public class AgeQuantizedToTicks : IGetAgeSumIntersect
    {
        /// <summary>
        /// // general formula is (pYears - cYears) / nChildren - 1
        /// </summary>
        /// <returns>Date when parent is the same age as the children combined.</returns>
        public DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            long pTicks = parent.Ticks;
            long cTicks = children.Sum(c => c.Ticks);

            long targetDateInTicks = (cTicks - pTicks) / (children.Length - 1);

            return new DateTime(targetDateInTicks);
        }
    }
}