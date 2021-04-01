using System;

namespace GlowingEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime parent = new DateTime(2000, 1, 1);

            DateTime firstTwin = new DateTime(2018, 1, 1);
            DateTime secondTwin = new DateTime(2018, 1, 1);
            Console.WriteLine(Age.GetAgeSumIntersect(parent, firstTwin, secondTwin));
        }
    }
}
