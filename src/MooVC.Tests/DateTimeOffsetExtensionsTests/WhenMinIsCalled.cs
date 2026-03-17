namespace MooVC.DateTimeOffsetExtensionsTests;

public sealed class WhenMinIsCalled
{
    public static IEnumerable<(DateTime Oldest, DateTime Newest)> GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData()
    {
        yield return (new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
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

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
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

    [Test]
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