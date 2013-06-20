using System;
using Refactor.Common;
using Refactor.Model;
using Xunit;

namespace Refactor.test
{
    public class BusinessFacts
    {
        private Business subject;

        public void SetUp()
        {
            subject = new Business();
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
            Assert.Equal(new Dollars(7.26), subject.Charge());
        }

        [Fact]
        public void Test99()
        {
            SetUp();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(7.19), subject.Charge());
        }

        [Fact]
        public void Test101()
        {
            SetUp();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(7.33), subject.Charge());
        }

        [Fact]
        public void Test199()
        {
            SetUp();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.41), subject.Charge());
        }

        [Fact]
        public void Test200()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.48), subject.Charge());
        }

        [Fact]
        public void Test201()
        {
            SetUp();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.55), subject.Charge());
        }

        [Fact]
        public void TestMax()
        {
            SetUp();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.5220290473E8), subject.Charge());
        }
    }
}