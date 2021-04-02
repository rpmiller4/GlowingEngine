using System;
using NUnit.Framework;
using GlowingEngine;

namespace GlowingEngine.Tests
{
    [TestFixture]
    public class AgeQuantizedToSecondsTests
    {
        private AgeQuantizedToSeconds _age;

        [OneTimeSetUp]
        public void Setup()
        {
            _age = new AgeQuantizedToSeconds();
        }

        [Test]
        public void WhenAgesAreSame_ReturnDateOfBirth()
        {
            DateTime parent = new DateTime(2021, 4, 1);
            DateTime child = new DateTime(2021, 4, 1);

            Assert.AreEqual(parent, _age.GetAgeSumIntersect(parent, child));
        }

        [Test]
        public void WhenParentHasTwoTwinsAtEighteen_ReturnDateOfBirthPlusEighteen()
        {
            DateTime parent = new DateTime(2000, 1, 1);

            DateTime firstTwin = new DateTime(2018, 1, 1);
            DateTime secondTwin = new DateTime(2018, 1, 1);

            var expectedIntersect = new DateTime(2036, 1, 1);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTwin, secondTwin));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSix_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 1, 1);

            DateTime firstTriplet = new DateTime(2006, 1, 1);
            DateTime secondTriplet = new DateTime(2006, 1, 1);
            DateTime thirdTriplet = new DateTime(2006, 1, 1);
            var expectedIntersect = new DateTime(2009, 1, 1);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSixOnFeb28_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 2, 28);

            DateTime firstTriplet = new DateTime(2006, 2, 28);
            DateTime secondTriplet = new DateTime(2006, 2, 28);
            DateTime thirdTriplet = new DateTime(2006, 2, 28);
            var expectedIntersect = new DateTime(2009, 2, 28);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
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

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtFourOnFeb29AtLastSecond_ReturnDateOfBirthPlusSix()
        {
            DateTime parent = new DateTime(2000, 2, 29, 23, 59, 59);

            DateTime firstTriplet = new DateTime(2004, 2, 29, 23, 59, 59);
            DateTime secondTriplet = new DateTime(2004, 2, 29, 23, 59, 59);
            DateTime thirdTriplet = new DateTime(2004, 2, 29, 23, 59, 59);
            var expectedIntersect = new DateTime(2006, 3, 1, 00, 00, 00);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtFourOnFeb29AtFirstSecond_ReturnDateOfBirthPlusSix()
        {
            DateTime parent = new DateTime(2000, 2, 29, 0, 0, 0);

            DateTime firstTriplet = new DateTime(2004, 2, 29, 0, 0, 0);
            DateTime secondTriplet = new DateTime(2004, 2, 29, 0, 0, 0);
            DateTime thirdTriplet = new DateTime(2004, 2, 29, 0, 0, 0);
            var expectedIntersect = new DateTime(2006, 3, 1, 0, 0, 0);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSixOnFeb28AtFirstSecond_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 2, 28, 0, 0, 0);

            DateTime firstTriplet = new DateTime(2006, 2, 28, 0, 0, 0);
            DateTime secondTriplet = new DateTime(2006, 2, 28, 0, 0, 0);
            DateTime thirdTriplet = new DateTime(2006, 2, 28, 0, 0, 0);
            var expectedIntersect = new DateTime(2009, 2, 28, 0, 0, 0);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }

        /// <summary>
        /// Expects 2009-02-28 23 59 59
        /// was 2009 02 28 00 00 00
        /// </summary>
        [Test]
        public void WhenParentGuardianHasAdoptiveTripletsAtSixOnFeb28AtLastSecond_ReturnDateOfBirthPlusNine()
        {
            DateTime parent = new DateTime(2000, 2, 28, 23, 59, 59);

            DateTime firstTriplet = new DateTime(2006, 2, 28, 23, 59, 59);
            DateTime secondTriplet = new DateTime(2006, 2, 28, 23, 59, 59);
            DateTime thirdTriplet = new DateTime(2006, 2, 28, 23, 59, 59);
            var expectedIntersect = new DateTime(2009, 2, 28, 00, 00, 00);

            Assert.AreEqual(expectedIntersect, _age.GetAgeSumIntersect(parent, firstTriplet, secondTriplet, thirdTriplet));
        }
    }
}
