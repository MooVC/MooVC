namespace MooVC.DateTimeOffsetExtensionsTests
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
        public void GivenDifferentDatesThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
        {
            var first = new DateTimeOffset(oldest);
            var second = new DateTimeOffset(newest);

            DateTimeOffset selected = first.Min(second);

            Assert.Equal(first, selected);
        }
    }
}