namespace MooVC.Linq.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

public sealed class WhenIsNullOrEmptyIsCalled
{
    [Fact]
    public void GivenAnEmptySourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = Array.Empty<int>();

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = isEmpty.Should().BeTrue();
    }

    [Fact]
    public void GivenAPopulatedSourceWithSingleElementThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[1];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = isEmpty.Should().BeFalse();
    }

    [Fact]
    public void GivenAPopulatedSourceWithMultipleElementsThenANegativeResponseIsReturned()
    {
        // Arrange
        IEnumerable<int> source = new int[3];

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = isEmpty.Should().BeFalse();
    }

    [Fact]
    public void GivenANullSourceThenAPositiveResponseIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        bool isEmpty = source.IsNullOrEmpty();

        // Assert
        _ = isEmpty.Should().BeTrue();
    }
}