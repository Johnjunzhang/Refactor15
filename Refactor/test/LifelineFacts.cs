using System;
using Refactor.Common;
using Refactor.Model;
using Xunit;

namespace Refactor.test
{
    public class LifelineFacts
    {
        private LifelineSite subject;

        public void SetUp()
        {
            subject = new LifelineSite();
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
            Assert.Equal(new Dollars(4.84), subject.Charge());
        }

        [Fact]
        public void Test99()
        {
            SetUp();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.79), subject.Charge());
        }

        [Fact]
        public void Test101()
        {
            SetUp();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.91), subject.Charge());
        }

        [Fact]
        public void Test199()
        {
            SetUp();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.61), subject.Charge());
        }

        [Fact]
        public void Test200()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.68), subject.Charge());
        }

        [Fact]
        public void Test201()
        {
            SetUp();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.77), subject.Charge());
        }

        [Fact]
        public void TestMax()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.9730005337E8), subject.Charge());
        }
    }
}