using System;
using Refactor.Common;
using Refactor.Model;
using Xunit;

namespace Refactor.test
{
    public class ResidentialFacts
    {
        private Residential subject;

        public void SetUp()
        {
            var zone = new Zone("B", 0.07, 0.06, new DateTime(1997, 6, 5), new DateTime(1997, 8, 31));
            subject = new Residential(zone);
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
            Assert.Equal(new Dollars(9.19), subject.Charge());
        }

        [Fact]
        public void Test99()
        {
            SetUp();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(9.10), subject.Charge());
        }

        [Fact]
        public void Test101()
        {
            SetUp();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(9.28), subject.Charge());
        }

        [Fact]
        public void Test199()
        {
            SetUp();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.28), subject.Charge());
        }

        [Fact]
        public void Test200()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.38), subject.Charge());
        }

        [Fact]
        public void Test201()
        {
            SetUp();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.47), subject.Charge());
        }

        [Fact]
        public void TestMax()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.9730006007E8), subject.Charge());
        }
    }
}