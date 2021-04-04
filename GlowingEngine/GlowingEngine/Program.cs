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

                TimeSpan parentAgeAsDuration = intersect - parent;
                TimeSpan firstChildAgeAsDuration = intersect - firstChild;
                TimeSpan secondChildAgeAsDuration = intersect - secondChild;

                int sumOfAllChildrenAges = ageFirstChild + ageSecondChild;
                TimeSpan sumOfAllChildrenAgesAsDuration = firstChildAgeAsDuration + secondChildAgeAsDuration;

                const double averageFractionalDaysInAGregorianCalendarYear = 365.2425;

                var fractionalAgeParent = parentAgeAsDuration.TotalDays / averageFractionalDaysInAGregorianCalendarYear;
                var fractionalAgeFirstChild = firstChildAgeAsDuration.TotalDays / averageFractionalDaysInAGregorianCalendarYear;
                var fractionalAgeSecondChild = secondChildAgeAsDuration.TotalDays / averageFractionalDaysInAGregorianCalendarYear;
                var fractionalSumOfChildrenAges = sumOfAllChildrenAgesAsDuration.TotalDays / averageFractionalDaysInAGregorianCalendarYear;


                Console.WriteLine($"Intersect: {intersect}");
                Console.WriteLine();
                Console.WriteLine("                 Age in Years, Age in Ticks, Age Fractional");
                Console.WriteLine("Age Parent:      {0}, {1}, {2}", ageParent, parentAgeAsDuration.Ticks, fractionalAgeParent);
                Console.WriteLine("Age FirstChild:  {0}, {1}, {2}", ageFirstChild, firstChildAgeAsDuration.Ticks, fractionalAgeFirstChild);
                Console.WriteLine("Age SecondChild: {0}, {1}, {2}", ageSecondChild, secondChildAgeAsDuration.Ticks, fractionalAgeSecondChild);
                Console.WriteLine("Sum Ages:        {0}, {1}, {2}", sumOfAllChildrenAges, sumOfAllChildrenAgesAsDuration.Ticks, fractionalSumOfChildrenAges);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
