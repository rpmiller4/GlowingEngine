using System;
using System.Linq;
using System.Threading;

namespace GlowingEngine
{
    public class Age
    {
        const int MaxInterval = 125;
        private const int AverageDaysInAYear = 365;

        public static DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            DateTime intersect = DateTime.MinValue;
            // naive method is to test each x interval since the children were born whether ages intersect.
            // start when parent is at the age of the youngest child.
            //int startOfInterval = CalculateAge()

            for (int i = 0; i < MaxInterval * AverageDaysInAYear; i++)
            {
                DateTime referenceCheckpoint = parent.AddDays(i);
                int parentAge = CalculateAge(parent, referenceCheckpoint);
                int childrenAge = children.Sum(child => CalculateAge(child, referenceCheckpoint));

                if (parentAge == childrenAge)
                {
                    intersect = parent.AddDays(i);
                    break;
                }
            }

            return intersect;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
        /// <remarks>I've used this before and it accounts for leap years, modified it to use a checkpoint argument.</remarks>
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        public static int CalculateAge(DateTime birthdate, DateTime checkpoint)
        {
            // Save the reference date
            var today = checkpoint;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}