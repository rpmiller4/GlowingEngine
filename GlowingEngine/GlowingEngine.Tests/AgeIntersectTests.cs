using System;
using NUnit.Framework;
using GlowingEngine;

namespace GlowingEngine.Tests
{
    [TestFixture]
    public class AgeIntersectTests
    {
        [Test]
        public void WhenAgesAreSame_ReturnDateOfBirth()
        {
            DateTime parent = new DateTime(2021, 4, 1);
            DateTime child = new DateTime(2021, 4, 1);

            Assert.AreEqual(parent, Age.GetAgeSumIntersect(parent, child));
        }

        [Test]
        public void WhenParentHasTwoTwinsAtEighteen_ReturnDateOfBirthPlusEighteen()
        {
            DateTime parent = new DateTime(2000, 1, 1);

            DateTime firstTwin = new DateTime(2018, 1, 1);
            DateTime secondTwin = new DateTime(2018, 1, 1);

            var expectedIntersect = new DateTime(2036, 1, 1);

            Assert.AreEqual(expectedIntersect, Age.GetAgeSumIntersect(parent, firstTwin, secondTwin));
        }
    }
}
