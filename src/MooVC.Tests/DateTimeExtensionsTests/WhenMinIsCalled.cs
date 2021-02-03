namespace MooVC.DateTimeExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenMinIsCalled
    {
        public static readonly IEnumerable<object[]> GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData = new[]
        {
            new object[] { new DateTime(2019, 1, 1), new DateTime(2019, 12, 31) },
            new object[] { new DateTime(2019, 1, 31), new DateTime(2019, 12, 1) },
            new object[] { new DateTime(2018, 12, 1), new DateTime(2019, 1, 31) },
            new object[] { new DateTime(2018, 12, 31), new DateTime(2019, 1, 1) },
        };

        [Theory]
        [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
        public void GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInThePastIsReturned(
            DateTime oldest,
            DateTime newest)
        {
            DateTime selected = oldest.Min(newest);

            Assert.Equal(oldest, selected);
        }

        [Theory]
        [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
        public void GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInThePastIsReturned(
            DateTime oldest,
            DateTime newest)
        {
            DateTime selected = newest.Min(oldest);

            Assert.Equal(oldest, selected);
        }
    }
}