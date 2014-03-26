using System;
using Refactoring_LongerExample;
using Xunit;

namespace Refactoring_LongerExampleFacts
{
    public class DisabilityFacts
    {
        [Fact]
        public void should_not_charge_given_reading_amount_not_changed()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void should_charge_8_14_given_reading_amount_increase_100()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.14), subject.Charge());
        }

        [Fact]
        public void should_charge_8_06_given_reading_amount_increase_99()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.06), subject.Charge());
        }

        [Fact]
        public void should_charge_8_22_given_reading_amount_increase_101()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(8.22), subject.Charge());
        }

        [Fact]
        public void should_charge_16_12_given_reading_amount_increase_199()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.12), subject.Charge());
        }

        [Fact]
        public void should_charge_16_20_given_reading_amount_increase_200()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.20), subject.Charge());
        }

        [Fact]
        public void should_charge_16_28_given_reading_amount_increase_201()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(16.28), subject.Charge());
        }

        [Fact]
        public void should_charge_given_reading_amount_max_increaseds()
        {
            var subject = CreateDisabilitySite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.7738214892E8), subject.Charge());
        }

        [Fact]
        public void should_throw_exception_given_no_reading()
        {
            var subject = CreateDisabilitySite();
            Assert.Throws<IndexOutOfRangeException>(() => subject.Charge());
        }

        public DisabilitySite CreateDisabilitySite()
        {
            var zone = new Zone("A", 0.06, 0.07, new DateTime(1997, 5, 15), new DateTime(1997, 9, 10));
            return new DisabilitySite(zone);
        }
    }
}