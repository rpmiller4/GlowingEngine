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

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSix_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 1, 1);

            DateTime firstTriplet = new DateTime(2006, 1, 1);
            DateTime secondTriplet = new DateTime(2006, 1, 1);
            DateTime thirdTriplet = new DateTime(2006, 1, 1);
            var expectedIntersect = new DateTime(2009, 1, 1);

            Assert.AreEqual(expectedIntersect, Age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSixOnFeb28_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 2, 28);

            DateTime firstTriplet = new DateTime(2006, 2, 28);
            DateTime secondTriplet = new DateTime(2006, 2, 28);
            DateTime thirdTriplet = new DateTime(2006, 2, 28);
            var expectedIntersect = new DateTime(2009, 2, 28);

            Assert.AreEqual(expectedIntersect, Age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        /// <summary>
        /// Expects 2006-3-1 but gets 2007-2-28 when using year granularity in GetAgeSumIntersect().
        /// Passes when using day granularity in GetAgeSumIntersect();
        /// </summary>
        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtFourOnFeb29_ReturnDateOfBirthPlusSix()
        {
            DateTime parent = new DateTime(2000, 2, 29);

            DateTime firstTriplet = new DateTime(2004, 2, 29);
            DateTime secondTriplet = new DateTime(2004, 2, 29);
            DateTime thirdTriplet = new DateTime(2004, 2, 29);
            var expectedIntersect = new DateTime(2006, 3, 1);

            Assert.AreEqual(expectedIntersect, Age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }
    }
}
