using System;
using NUnit.Framework;

namespace SSB.Core.Test
{
    [TestFixture]
    public class RandomStringTest
    {
        [Test]
        public void GetNextStringTest()
        {
            int expectedLenght = 1000;
            var random = new Random();
            string actual = random.NextString(expectedLenght);
            Assert.AreEqual(expectedLenght, actual.Length);
        }
    }
}
