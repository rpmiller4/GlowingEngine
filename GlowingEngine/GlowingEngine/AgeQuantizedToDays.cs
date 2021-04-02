using System;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace GlowingEngine
{
    public class AgeQuantizedToDays : IGetAgeSumIntersect
    {
        private const long MaxInterval = 125;
        private const long AverageDaysInAYear = 365;

        public DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            DateTime intersect = DateTime.MinValue;

            for (long i = 0; i < MaxInterval * AverageDaysInAYear; i++)
            {
                DateTime referenceCheckpoint = parent.AddDays(i);
                int parentAge = Utilities.CalculateAge(parent, referenceCheckpoint);
                int childrenAge = children.Sum(child => Utilities.CalculateAge(child, referenceCheckpoint));

                if (parentAge == childrenAge)
                {
                    intersect = parent.AddDays(i);
                    break;
                }
            }

            return intersect;
        }
    }
}