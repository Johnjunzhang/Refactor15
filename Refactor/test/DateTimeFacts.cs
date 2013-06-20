using System;
using Refactor.Common;
using Xunit;

namespace Refactor.test
{
    public class DateTimeFacts
    {
        [Fact]
        public void TestBefore()
        {
            Assert.True(new DateTime(2011, 1, 1).Before(new DateTime(2011, 1, 2)));
        }

        [Fact]
        public void TestAfter()
        {
            Assert.True(new DateTime(2011, 1, 3).After(new DateTime(2011, 1, 2)));
        }

        [Fact]
        public void TestSetDate()
        {
            Assert.Equal(new DateTime(2011, 1, 15).SetDate(3), new DateTime(2011, 1, 3));
        }

        [Fact]
        public void TestGetDate()
        {
            Assert.Equal(new DateTime(2011, 1, 3).GetDate(), 3);
        }
    }
}