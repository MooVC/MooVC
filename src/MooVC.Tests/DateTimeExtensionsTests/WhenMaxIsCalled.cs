namespace MooVC.DateTimeExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
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
    public void GivenDifferentDatesWhenTheFirstDateIsTheOldestThenTheDateFurthestInTheFuturetIsReturnedData(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = oldest.Max(newest);

        // Assert
        _ = selected.Should().Be(newest);
    }

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstDateIsTheNewestThenTheDateFurthestInTheFuturetIsReturned(
        DateTime oldest,
        DateTime newest)
    {
        // Act
        DateTime selected = newest.Max(oldest);

        // Assert
        _ = selected.Should().Be(newest);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTime(2019, 1, 1);

        // Act
        DateTime selected = sameDate.Max(sameDate);

        // Assert
        _ = selected.Should().Be(sameDate);
    }
}