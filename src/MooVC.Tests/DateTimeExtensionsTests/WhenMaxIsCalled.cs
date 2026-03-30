namespace MooVC.DateTimeExtensionsTests;

public sealed class WhenMaxIsCalled
{
    public static IEnumerable<(DateTime Oldest, DateTime Newest)> GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData()
    {
        yield return (new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc));
        yield return (new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc));
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
    public async Task GivenDifferentDatesWhenTheFirstDateIsTheNewestThenTheDateFurthestInTheFuturetIsReturned(
        DateTime oldest,
        DateTime newest)
    {
        // Act
        DateTime selected = newest.Max(oldest);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(newest);
    }

    [Test]
    [MethodDataSource(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
    public async Task GivenDifferentDatesWhenTheFirstDateIsTheOldestThenTheDateFurthestInTheFuturetIsReturnedData(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = oldest.Max(newest);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(newest);
    }

    [Test]
    public async Task GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        DateTime selected = sameDate.Max(sameDate);

        // Assert
        _ = await Assert.That(selected).IsEqualTo(sameDate);
    }
}