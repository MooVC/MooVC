namespace MooVC.ObjectExtensionsTests;

public sealed class WhenToTypedArrayIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenAnArrayThenTheSameArrayIsReturned()
    {
        // Arrange
        int[] expected = [1, 2, 3];

        // Act
        int[] value = expected.ToTypedArray();

        // Assert
        value.ShouldBeSameAs(expected);
    }

    [Fact]
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