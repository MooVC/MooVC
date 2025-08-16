namespace MooVC.DateTimeOffsetExtensionsTests;

public sealed class WhenMaxIsCalled
{
    public static readonly TheoryData<DateTime, DateTime> GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData = new()
    {
        { new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
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
        selected.ShouldBe(second);
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
        selected.ShouldBe(first);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        DateTimeOffset selected = sameDate.Max(sameDate);

        // Assert
        selected.ShouldBe(sameDate);
    }
}