using System;
using System.Linq;

namespace GlowingEngine
{
    public class AgeQuantizedToSeconds : IGetAgeSumIntersect
    {
        private const long MaxInterval = 125;
        private const long AverageDaysInAYear = 365;
        private const long AverageSecondsInADay = 86400;

        public DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            DateTime intersect = DateTime.MinValue;

            for (long i = 0; i < MaxInterval * AverageDaysInAYear * AverageSecondsInADay; i++)
            {
                DateTime referenceCheckpoint = parent.AddSeconds(i);
                int parentAge = Utilities.CalculateAge(parent, referenceCheckpoint);
                int childrenAge = children.Sum(child => Utilities.CalculateAge(child, referenceCheckpoint));

                if (parentAge == childrenAge)
                {
                    intersect = parent.AddSeconds(i);
                    break;
                }
            }

            return intersect;
        }
    }
}