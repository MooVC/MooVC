namespace MooVC.ObjectExtensionsTests;

public sealed class WhenToTypedArrayIsCalled
{
    [Test]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        TimeSpan[] value = expected.ToTypedArray();

        // Assert
        value.Length.ShouldBe(1);
        value.Single().ShouldBe(expected);
    }

    [Test]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        TimeSpan?[] value = expected.ToTypedArray();

        // Assert
        value.Length.ShouldBe(1);
        value.Single().ShouldBeNull();
    }

    [Test]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        object[] value = expected.ToTypedArray();

        // Assert
        value.Length.ShouldBe(1);
        value.Single().ShouldBeSameAs(expected);
    }

    [Test]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        object?[] value = expected.ToTypedArray();

        // Assert
        value.Length.ShouldBe(1);
        value.Single().ShouldBeNull();
    }

    [Test]
    public void GivenAnArrayThenTheSameArrayIsReturned()
    {
        // Arrange
        int[] expected = [1, 2, 3];

        // Act
        int[]? value = expected.ToTypedArray();

        // Assert
        value.ShouldBeSameAs(expected);
    }

    [Test]
    public void GivenANullArrayThenNullIsReturned()
    {
        // Arrange
        int[]? expected = default;

        // Act
        int[]? value = expected.ToTypedArray();

        // Assert
        value.ShouldBeNull();
    }
}