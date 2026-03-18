namespace MooVC.ObjectExtensionsTests;

public sealed class WhenToTypedArrayIsCalled
{
    [Test]
    public async Task GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        TimeSpan[] value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value.Length).IsEqualTo(1);
        _ = await Assert.That(value.Single()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        TimeSpan?[] value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value.Length).IsEqualTo(1);
        _ = await Assert.That(value.Single()).IsNull();
    }

    [Test]
    public async Task GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        object[] value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value.Length).IsEqualTo(1);
        _ = await Assert.That(value.Single()).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        object?[] value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value.Length).IsEqualTo(1);
        _ = await Assert.That(value.Single()).IsNull();
    }

    [Test]
    public async Task GivenAnArrayThenTheSameArrayIsReturned()
    {
        // Arrange
        int[] expected = [1, 2, 3];

        // Act
        int[]? value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value).IsSameReferenceAs(expected);
    }

    [Test]
    public async Task GivenANullArrayThenNullIsReturned()
    {
        // Arrange
        int[]? expected = default;

        // Act
        int[]? value = expected.ToTypedArray();

        // Assert
        _ = await Assert.That(value).IsNull();
    }
}