namespace MooVC.DateTimeOffsetExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using MooVC;
using Xunit;

public sealed class WhenMaxIsCalled
{
    public static readonly IEnumerable<object[]> GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData = new[]
    {
        new object[] { new DateTime(2019, 1, 1), new DateTime(2019, 12, 31) },
        new object[] { new DateTime(2019, 1, 31), new DateTime(2019, 12, 1) },
        new object[] { new DateTime(2018, 12, 1), new DateTime(2019, 1, 31) },
        new object[] { new DateTime(2018, 12, 31), new DateTime(2019, 1, 1) },
    };

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInTheFutureIsReturned(DateTime oldest, DateTime newest)
    {
        // Arrange
        var first = new DateTimeOffset(oldest);
        var second = new DateTimeOffset(newest);

        // Act
        DateTimeOffset selected = first.Max(second);

        // Assert
        _ = selected.Should().Be(second);
    }

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInTheFutureIsReturned(DateTime oldest, DateTime newest)
    {
        // Arrange
        var first = new DateTimeOffset(newest);
        var second = new DateTimeOffset(oldest);

        // Act
        DateTimeOffset selected = first.Max(second);

        // Assert
        _ = selected.Should().Be(first);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTimeOffset(new DateTime(2019, 1, 1));

        // Act
        DateTimeOffset selected = sameDate.Max(sameDate);

        // Assert
        _ = selected.Should().Be(sameDate);
    }
}