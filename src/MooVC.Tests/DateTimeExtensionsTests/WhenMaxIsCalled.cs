namespace MooVC.DateTimeExtensionsTests;

public sealed class WhenMaxIsCalled
{
    public static readonly TheoryData<DateTime, DateTime> GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData = new()
    {
        { new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 12, 1, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 31, 0, 0, 0, DateTimeKind.Utc) },
        { new(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc), new(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
    };

    [Theory]
    [MemberData(nameof(GivenDifferentDatesThenTheDateFurthestInTheFuturetIsReturnedData))]
    public void GivenDifferentDatesWhenTheFirstDateIsTheOldestThenTheDateFurthestInTheFuturetIsReturnedData(DateTime oldest, DateTime newest)
    {
        // Act
        DateTime selected = oldest.Max(newest);

        // Assert
        selected.ShouldBe(newest);
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
        selected.ShouldBe(newest);
    }

    [Fact]
    public void GivenSameDatesThenTheSameDateIsReturned()
    {
        // Arrange
        var sameDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        DateTime selected = sameDate.Max(sameDate);

        // Assert
        selected.ShouldBe(sameDate);
    }
}