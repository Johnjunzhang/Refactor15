using System;
using Refactoring_LongerExample;
using Xunit;

namespace Refactoring_LongerExampleFacts
{
    public class ResidentialFacts
    {
        [Fact]
        public void should_not_charge_given_reading_amount_not_changed()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(0), subject.Charge());
        }

        [Fact]
        public void should_charge_9_19_given_reading_amount_increase_100()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(10, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(110, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(9.19), subject.Charge());
        }

        [Fact]
        public void should_charge_9_10_given_reading_amount_increase_99()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(100, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(9.10), subject.Charge());
        }

        [Fact]
        public void should_charge_9_28_given_reading_amount_increase_101()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(1000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(1101, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(9.28), subject.Charge());
        }

        [Fact]
        public void should_charge_18_28_given_reading_amount_increase_199()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(10000, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(10199, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.28), subject.Charge());
        }

        [Fact]
        public void should_charge_18_38_given_reading_amount_increase_200()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(200, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.38), subject.Charge());
        }

        [Fact]
        public void should_charge_18_47_given_reading_amount_increase_201()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(50, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(251, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(18.47), subject.Charge());
        }

        [Fact]
        public void should_charge_given_reading_amount_max_increaseds()
        {
            var subject = CreateResidentialSite();
            subject.AddReading(new Reading(0, new DateTime(1997, 1, 1)));
            subject.AddReading(new Reading(int.MaxValue, new DateTime(1997, 2, 1)));
            Assert.Equal(new Dollars(1.9730006007E8), subject.Charge());
        }

        [Fact]
        public void should_throw_exception_given_no_reading()
        {
            var subject = CreateResidentialSite();
            Assert.Throws<IndexOutOfRangeException>(() => subject.Charge());
        }

        public ResidentialSite CreateResidentialSite()
        {
            var zone = new Zone("B", 0.07, 0.06, new DateTime(1997, 6, 5), new DateTime(1997, 8, 31));
            return new ResidentialSite(zone);
        }
    }
}