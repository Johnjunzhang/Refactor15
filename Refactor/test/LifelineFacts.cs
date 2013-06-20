using System;
using Refactor.Model;
using Refactor.Utils;
using Xunit;

namespace Refactor.test
{
    public class LifelineFacts
    {
        private LifelineSite subject;

        [Fact]
        public void TestZero()
        {
            SetUp();
            subject.addReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void Test100()
        {
            SetUp();
            subject.addReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.84), subject.Charge());
        }

        [Fact]
        public void Test99()
        {
            SetUp();
            subject.addReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.79), subject.Charge());
        }

        [Fact]
        public void Test101()
        {
            SetUp();
            subject.addReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.91), subject.Charge());
        }

        [Fact]
        public void Test199()
        {
            SetUp();
            subject.addReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.61), subject.Charge());
        }

        [Fact]
        public void Test200()
        {
            SetUp();
            subject.addReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.68), subject.Charge());
        }

        [Fact]
        public void Test201()
        {
            SetUp();
            subject.addReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.77), subject.Charge());
        }

        [Fact]
        public void TestMax()
        {
            SetUp();
            subject.addReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.addReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.9730005337E8), subject.Charge());
        }

        [Fact]
        public void TesttNoReadings()
        {
            SetUp();
            Assert.Throws<NullReferenceException>(() => subject.Charge());
        }


        public void SetUp()
        {
//            Registry.add("Unit", new Unit("USD"));
            new Zone("A", 0.06, 0.07, new DateTime(1997, 5, 15), new DateTime(1997, 9, 10)); //.register();
            new Zone("B", 0.07, 0.06, new DateTime(1997, 6, 5), new DateTime(1997, 8, 31)); //.register();
            new Zone("C", 0.065, 0.065, new DateTime(1997, 6, 5), new DateTime(1997, 8, 31)); //.register();
            subject = new LifelineSite();
        }
    }
}