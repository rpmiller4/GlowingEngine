using System;
using System.Linq;

namespace GlowingEngine
{
    public class Age
    {
        public static DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children)
        {
            // naive method is to test each x interval since the children were born whether ages intersect.

            // tests will naturally fail.

            return DateTime.MinValue;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
        /// <remarks>I've used this before and it accounts for leap years.</remarks>
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        public static int CalculateAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}