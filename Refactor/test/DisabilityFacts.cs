using System;
using Refactor.Common;
using Refactor.Model;
using Xunit;

namespace Refactor.test
{
    public class DisabilityFacts
    {
        private DisabilitySite subject;

        public void SetUp()
        {
            var zone = new Zone("A", 0.06, 0.07, new DateTime(1997, 5, 15), new DateTime(1997, 9, 10));
            subject = new DisabilitySite(zone);
        }

        [Fact]
        public void TestZero()
        {
            SetUp();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void Test100()
        {
            SetUp();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.14), subject.Charge());
        }

        [Fact]
        public void Test99()
        {
            SetUp();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.06), subject.Charge());
        }

        [Fact]
        public void Test101()
        {
            SetUp();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.22), subject.Charge());
        }

        [Fact]
        public void Test199()
        {
            SetUp();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.12), subject.Charge());
        }

        [Fact]
        public void Test200()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.20), subject.Charge());
        }

        [Fact]
        public void Test201()
        {
            SetUp();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.28), subject.Charge());
        }

        [Fact]
        public void TestMax()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.7738214892E8), subject.Charge());
        }

        [Fact]
        public void TesttNoReadings()
        {
            SetUp();
            Assert.Throws<IndexOutOfRangeException>(() => subject.Charge());
        }
    }
}