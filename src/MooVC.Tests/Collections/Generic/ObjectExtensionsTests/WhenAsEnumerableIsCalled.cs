namespace MooVC.Collections.Generic.ObjectExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

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
        _ = value.Should().ContainSingle()
            .Which.Should().Be(expected);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        IEnumerable<TimeSpan?> value = expected.AsEnumerable();

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
        IEnumerable<object> value = expected.AsEnumerable();

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
        IEnumerable<object?> value = expected.AsEnumerable();

        // Assert
        _ = value.Should().ContainSingle()
            .Which.Should().BeNull();
    }
}