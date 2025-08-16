namespace MooVC.DateTimeOffsetExtensionsTests;

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
        // Arrange
        var first = new DateTimeOffset(oldest);
        var second = new DateTimeOffset(newest);

        // Act
        DateTimeOffset selected = first.Min(second);

        // Assert
        selected.ShouldBe(first);
    }

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
    {
        // Arrange
        var first = new DateTimeOffset(newest);
        var second = new DateTimeOffset(oldest);

        // Act
        DateTimeOffset selected = first.Min(second);

        // Assert
        selected.ShouldBe(second);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        DateTimeOffset selected = sameDate.Min(sameDate);

        // Assert
        selected.ShouldBe(sameDate);
    }
}