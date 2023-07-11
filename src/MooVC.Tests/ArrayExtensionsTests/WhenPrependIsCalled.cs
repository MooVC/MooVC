namespace MooVC.ArrayExtensionsTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenPrependIsCalled
{
    [Fact]
    public void GivenANullArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        // Arrange
        int[]? original = default;
        int expected = 5;

        // Act
        int[] result = original.Prepend(expected);

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
        int[] result = original.Prepend(expected);

        // Assert
        _ = result.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenAnArrayThenAnArrayIsReturnedWithTheElementAtTheStart()
    {
        // Arrange
        int[] original = new[] { 2, 3, 4 };
        int[] expected = new[] { 1, 2, 3, 4 };
        int value = 1;

        // Act
        int[] actual = original.Prepend(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnArrayWithMultipleSimilarElementsThenAnArrayIsReturnedWithTheNewElementAtTheStart()
    {
        // Arrange
        int[] original = new[] { 1, 1, 1 };
        int[] expected = new[] { 2, 1, 1, 1 };
        int value = 2;

        // Act
        int[] actual = original.Prepend(value);

        // Assert
        _ = actual.Should().Equal(expected);
    }
}