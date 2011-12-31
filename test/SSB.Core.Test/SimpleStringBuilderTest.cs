using System;
using NUnit.Framework;

namespace SSB.Core.Test
{
    [TestFixture]
    public class SimpleStringBuilderTest
    {
        private ISimpleStringBuilder _sb;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            _sb = new SimpleStringBuilder();
            _random = new Random();
        }

        [Test]
        public void SingleAppendLessThenCapacityTest()
        {
            int size = SimpleStringBuilder.DefaultCapacity - 1;
            string expectedData = _random.NextString(size);
            _sb.Append(expectedData);
            string actual = _sb.ToString();
            Assert.AreEqual(expectedData, actual);
        }

        [Test]
        public void TwoAppendsMoreThanDefaultCapacityTest()
        {
            int size = SimpleStringBuilder.DefaultCapacity - 1;
            string expectedData = _random.NextString(size);
            _sb.Append(expectedData);
            _sb.Append(expectedData);
            string actual = _sb.ToString();
            Assert.AreEqual(expectedData + expectedData, actual);
        }

        [Test]
        public void OneLargeAppendMoreThanDefaultCapacityTest()
        {
            int size = SimpleStringBuilder.DefaultCapacity * 10 + 1;
            string expectedData = _random.NextString(size);
            _sb.Append(expectedData);
            string actual = _sb.ToString();
            Assert.AreEqual(expectedData, actual);
        }

        [Test]
        public void ClearLeavesAnEmptyStringTest()
        {
            int size = SimpleStringBuilder.DefaultCapacity + 1;
            string expectedData = _random.NextString(size);
            _sb.Append(expectedData);
            _sb.Clear();
            string actual = _sb.ToString();
            Assert.AreEqual(String.Empty, actual);
        }

        [Test]
        public void ClearSetLenghtToZeroTest()
        {
            int size = SimpleStringBuilder.DefaultCapacity *2 - 1;
            string expectedData = _random.NextString(size);
            _sb.Append(expectedData);
            _sb.Clear();
            Assert.AreEqual(0, _sb.Lenght);
        }
    }
}
