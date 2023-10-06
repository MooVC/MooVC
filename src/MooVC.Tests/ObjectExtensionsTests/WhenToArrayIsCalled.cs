namespace MooVC.ObjectExtensionsTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenToArrayIsCalled
{
    [Fact]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        var expected = TimeSpan.FromHours(1);

        // Act
        TimeSpan[] value = expected.ToArray();

        // Assert
        _ = value.Should().HaveCount(1);
        _ = value.Single().Should().Be(expected);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        TimeSpan? expected = default;

        // Act
        TimeSpan?[] value = expected.ToArray();

        // Assert
        _ = value.Should().HaveCount(1);
        _ = value.Single().Should().BeNull();
    }

    [Fact]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        // Arrange
        object expected = new();

        // Act
        object[] value = expected.ToArray();

        // Assert
        _ = value.Should().HaveCount(1);
        _ = value.Single().Should().BeSameAs(expected);
    }

    [Fact]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        // Arrange
        object? expected = default;

        // Act
        object?[] value = expected.ToArray();

        // Assert
        _ = value.Should().HaveCount(1);
        _ = value.Single().Should().BeNull();
    }
}