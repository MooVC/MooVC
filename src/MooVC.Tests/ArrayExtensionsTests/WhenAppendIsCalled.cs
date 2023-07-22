namespace MooVC.ArrayExtensionsTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenAppendIsCalled
{
    [Fact]
    public void GivenANullArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenAnEmptyArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[] original = Array.Empty<int>();
        int expected = 1;

        // Act
        int[] result = original.Append(expected);

        // Assert
        _ = result.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenAnArrayThenAnArrayIsReturnedWithTheElementAtTheEnd()
    {
        // Arrange
        int[] original = new[] { 1, 2, 3 };
        int[] expected = new[] { 1, 2, 3, 4 };
        int value = 4;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnArrayWithMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheEnd()
    {
        // Arrange
        int[] original = new[] { 1, 1, 1 };
        int[] expected = new[] { 1, 1, 1, 1 };
        int value = 1;

        // Act
        int[] actual = original.Append(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }
}