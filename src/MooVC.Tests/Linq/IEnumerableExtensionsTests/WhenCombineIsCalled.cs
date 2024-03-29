﻿namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenCombineIsCalled
{
    [Fact]
    public void GivenAnInstanceAndASourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        const int ExpectedCount = 4;
        int[] source = [1, 2, 3];

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        _ = actual.Should().HaveCount(ExpectedCount);
        _ = actual.Should().Contain(ExpectedValue);
    }

    [Fact]
    public void GivenAnInstanceAndANullSourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        IEnumerable<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        _ = actual.Should().ContainSingle()
            .Which.Should().Be(ExpectedValue);
    }

    [Fact]
    public void GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = default;

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedCount = 6;
        IEnumerable<int>? source = [1, 2, 3];
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = actual.Should().HaveCount(ExpectedCount);
        _ = actual.Should().Contain(source);
        _ = actual.Should().Contain(expected);
    }

    [Fact]
    public void GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }
}