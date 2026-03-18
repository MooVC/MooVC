namespace MooVC.Linq.ObjectExtensionsTests;

public sealed class WhenAsEnumerableIsCalled
{
    [Test]
    public async Task GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        IEnumerable<TimeSpan> value = expected.AsEnumerable();

        // Assert
        _ = await Assert.That(value.Single()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        IEnumerable<TimeSpan?> value = expected.AsEnumerable();

        // Assert
        _ = await Assert.That(value.Single()).IsNull();
    }

    [Test]
    public async Task GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        IEnumerable<object> value = expected.AsEnumerable();

        // Assert
        _ = await Assert.That(value.Single()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        IEnumerable<object?> value = expected.AsEnumerable();

        // Assert
        _ = await Assert.That(value.Single()).IsNull();
    }
}