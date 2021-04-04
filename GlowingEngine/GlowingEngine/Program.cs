using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static GlowingEngine.Utilities;

namespace GlowingEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IGetAgeSumIntersect> ageSolvers = new List<IGetAgeSumIntersect>()
            {
                new AgeQuantizedToCultureYears(),
                new AgeQuantizedToTicks(),
            };


            foreach (var ageSolver in ageSolvers)
            {
                Console.WriteLine("Using AgeSolver of type {0}", (ageSolver.GetType().Name));
                Console.WriteLine();

                DateTime parent = new DateTime(1956, 6, 24);
                DateTime firstChild = new DateTime(1975, 9, 15);
                DateTime secondChild = new DateTime(2012, 2, 24);

                DateTime intersect = ageSolver.GetAgeSumIntersect(parent, firstChild, secondChild);

                var ageParent = CalculateAge(parent, intersect);
                var ageFirstChild = CalculateAge(firstChild, intersect);
                var ageSecondChild = CalculateAge(secondChild, intersect);

                var parentAgeInTicks = intersect.Ticks - parent.Ticks;
                var firstChildAgeInTicks = intersect.Ticks - firstChild.Ticks;
                var secondChildAgeInTicks = intersect.Ticks - secondChild.Ticks;

                var sumOfAllChildrenAges = ageFirstChild + ageSecondChild;
                var sumOfAllChildrenAgesInTicks = firstChildAgeInTicks + secondChildAgeInTicks;

                // Using Gregorian Calendar to get Age in Decimal Precision Years
                Console.WriteLine($"Intersect: {intersect}");
                Console.WriteLine("                 Age in Years, Age in Ticks, Age Decimal");
                Console.WriteLine("Age Parent:      {0}, {1}, {2}", ageParent, parentAgeInTicks, new TimeSpan(parentAgeInTicks).TotalDays / 365.2425);
                Console.WriteLine("Age FirstChild:  {0}, {1}, {2}", ageFirstChild, firstChildAgeInTicks, new TimeSpan(firstChildAgeInTicks).TotalDays / 365.2425);
                Console.WriteLine("Age SecondChild: {0}, {1}, {2}", ageSecondChild, secondChildAgeInTicks, new TimeSpan(secondChildAgeInTicks).TotalDays / 365.2425);
                Console.WriteLine("Sum Ages:        {0}, {1}, {2}", sumOfAllChildrenAges, sumOfAllChildrenAgesInTicks, new TimeSpan(sumOfAllChildrenAgesInTicks).TotalDays / 365.2425);
                Console.WriteLine();
            }
        }
    }
}
