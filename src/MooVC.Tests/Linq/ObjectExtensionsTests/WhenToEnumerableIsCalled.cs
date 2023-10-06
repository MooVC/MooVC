namespace MooVC.Linq.ObjectExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using MooVC.Linq;
using Xunit;

public sealed class WhenToEnumerableIsCalled
{
    [Fact]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        IEnumerable<TimeSpan> value = expected.ToEnumerable();

        // Assert
        _ = value.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        IEnumerable<TimeSpan?> value = expected.ToEnumerable();

        // Assert
        _ = value.Should().ContainSingle()
            .Which.Should().BeNull();
    }

    [Fact]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        IEnumerable<object> value = expected.ToEnumerable();

        // Assert
        _ = value.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        IEnumerable<object?> value = expected.ToEnumerable();

        // Assert
        _ = value.Should().ContainSingle()
            .Which.Should().BeNull();
    }
}