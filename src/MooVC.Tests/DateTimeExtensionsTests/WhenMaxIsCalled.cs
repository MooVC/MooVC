namespace MooVC.DateTimeExtensionsTests
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
        public void GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturned(DateTime oldest, DateTime newest)
        {
            DateTime selected = oldest.Max(newest);

            Assert.Equal(newest, selected);
        }
    }
}