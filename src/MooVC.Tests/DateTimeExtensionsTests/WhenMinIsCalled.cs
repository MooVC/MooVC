namespace MooVC.DateTimeExtensionsTests;

public sealed class WhenMinIsCalled
{
    public static readonly TheoryData<DateTime, DateTime> GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData = new()
    {
        { new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    };

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = oldest.Min(newest);

        // Assert
        _ = selected.Should().Be(oldest);
    }

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = newest.Min(oldest);

        // Assert
        _ = selected.Should().Be(oldest);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        DateTime selected = sameDate.Min(sameDate);

        // Assert
        _ = selected.Should().Be(sameDate);
    }
}