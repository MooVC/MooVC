namespace MooVC.DateTimeOffsetExtensionsTests;

public sealed class WhenMaxIsCalled
{
    public static IEnumerable<(DateTime Oldest, DateTime Newest)> GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData()
    {
        yield return (new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData))]
    public async Task GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInTheFutureIsReturned(DateTime oldest, DateTime newest)
    {
        // Arrange
        var first = new DateTimeOffset(newest);
        var second = new DateTimeOffset(oldest);

        // Act
        DateTimeOffset selected = first.Max(second);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(first);
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInTheFutureIsReturnedData))]
    public async Task GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInTheFutureIsReturned(DateTime oldest, DateTime newest)
    {
        // Arrange
        var first = new DateTimeOffset(oldest);
        var second = new DateTimeOffset(newest);

        // Act
        DateTimeOffset selected = first.Max(second);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(second);
    }

    [Test]
    public async Task GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        DateTimeOffset selected = sameDate.Max(sameDate);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(sameDate);
    }
}