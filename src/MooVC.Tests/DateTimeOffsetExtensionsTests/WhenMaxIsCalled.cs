namespace MooVC.DateTimeOffsetExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using MooVC;
    using Xunit;

    public sealed class WhenMaxIsCalled
    {
        public static readonly IEnumerable<object[]> GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData = new[]
        {
            new object[] { new DateTime(2019, 1, 1), new DateTime(2019, 12, 31) },
            new object[] { new DateTime(2019, 1, 31), new DateTime(2019, 12, 1) },
            new object[] { new DateTime(2018, 12, 1), new DateTime(2019, 1, 31) },
            new object[] { new DateTime(2018, 12, 31), new DateTime(2019, 1, 1) },
        };

        [Theory]
        [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
        public void GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInTheFuturetIsReturned(
            DateTime oldest,
            DateTime newest)
        {
            var first = new DateTimeOffset(oldest);
            var second = new DateTimeOffset(newest);

            DateTimeOffset selected = first.Max(second);

            Assert.Equal(second, selected);
        }

        [Theory]
        [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
        public void GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInTheFuturetIsReturned(
            DateTime oldest,
            DateTime newest)
        {
            var first = new DateTimeOffset(newest);
            var second = new DateTimeOffset(oldest);

            DateTimeOffset selected = first.Max(second);

            Assert.Equal(first, selected);
        }
    }
}