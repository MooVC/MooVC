namespace MooVC.DateTimeExtensionsTests;

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
    public async Task GivenDifferentDatesWhenTheFirstIsTheOldestThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = oldest.Min(newest);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(oldest);
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInThePastIsReturnedData))]
    public async Task GivenDifferentDatesWhenTheFirstIsTheNewestThenTheDateFurthestInThePastIsReturned(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = newest.Min(oldest);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(oldest);
    }

    [Test]
    public async Task GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        DateTime selected = sameDate.Min(sameDate);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(sameDate);
    }
}