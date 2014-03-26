using System;
using Refactoring_LongerExample;
using Xunit;

namespace Refactoring_LongerExampleFacts
{
    public class BusinessFacts
    {
        [Fact]
        public void should_not_charge_given_reading_amount_not_changed()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void should_charge_7_26_given_reading_amount_increase_100()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(7.26), subject.Charge());
        }

        [Fact]
        public void should_charge_7_19_given_reading_amount_increase_99()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(7.19), subject.Charge());
        }

        [Fact]
        public void should_charge_7_33_given_reading_amount_increase_101()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(7.33), subject.Charge());
        }

        [Fact]
        public void should_charge_14_41_given_reading_amount_increase_101()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.41), subject.Charge());
        }

        [Fact]
        public void should_charge_14_48_given_reading_amount_increase_200()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.48), subject.Charge());
        }

        [Fact]
        public void should_charge_14_5_given_reading_amount_increase_201()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(14.55), subject.Charge());
        }

        [Fact]
        public void should_charge_given_reading_amount_max_increaseds()
        {
            var subject = new BusinessSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.5220290473E8), subject.Charge());
        }

        [Fact]
        public void should_throw_exception_given_no_reading()
        {
            var subject = new BusinessSite();
            Assert.Throws<NullReferenceException>(() => subject.Charge());
        }
    }
}