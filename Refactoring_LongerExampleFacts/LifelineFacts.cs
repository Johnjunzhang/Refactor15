using System;
using Refactoring_LongerExample;
using Xunit;

namespace Refactoring_LongerExampleFacts
{
    public class LifelineFacts
    {
        [Fact]
        public void should_not_charge_given_reading_amount_not_changed()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void should_charge_4_84_given_reading_amount_increase_100()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.84), subject.Charge());
        }

        [Fact]
        public void should_charge_4_79_given_reading_amount_increase_99()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.79), subject.Charge());
        }

        [Fact]
        public void should_charge_4_91_given_reading_amount_increase_101()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(4.91), subject.Charge());
        }

        [Fact]
        public void should_charge_11_61_given_reading_amount_increase_199()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.61), subject.Charge());
        }

        [Fact]
        public void should_charge_11_68_given_reading_amount_increase_200()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.68), subject.Charge());
        }

        [Fact]
        public void should_charge_11_77_given_reading_amount_increase_201()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(11.77), subject.Charge());
        }

        [Fact]
        public void should_charge_given_reading_amount_max_increaseds()
        {
            var subject = new LifelineSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.9730005337E8), subject.Charge());
        }

        [Fact]
        public void should_throw_exception_given_no_reading()
        {
            var subject = new LifelineSite();
            Assert.Throws<NullReferenceException>(() => subject.Charge());
        }
    }
}