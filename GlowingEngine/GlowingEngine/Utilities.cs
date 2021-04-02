using System;

namespace GlowingEngine
{
    public static class Utilities
    { 
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