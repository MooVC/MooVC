namespace MooVC.Linq.ObjectExtensionsTests;

public sealed class WhenAsEnumerableIsCalled
{
    [Fact]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        IEnumerable<TimeSpan> value = expected.AsEnumerable();

        // Assert
        value.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        IEnumerable<TimeSpan?> value = expected.AsEnumerable();

        // Assert
        value.ShouldHaveSingleItem().ShouldBeNull();
    }

    [Fact]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        IEnumerable<object> value = expected.AsEnumerable();

        // Assert
        value.ShouldHaveSingleItem().ShouldBe(expected);
    }

    [Fact]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        IEnumerable<object?> value = expected.AsEnumerable();

        // Assert
        value.ShouldHaveSingleItem().ShouldBeNull();
    }
}