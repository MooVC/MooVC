namespace MooVC.Serialization.DefaultClonerTests;

using System;
using FluentAssertions;
using Moq;
using Xunit;

public sealed class WhenDefaultClonerIsConstructed
{
    [Fact]
    public void GivenASerializerThenAnInstanceIsReturned()
    {
        // Arrange
        var serializer = new Mock<ISerializer>();

        // Act
        var cloner = new DefaultCloner(serializer.Object);

        // Assert
        _ = cloner.Should().NotBeNull();
    }

    [Fact]
    public void GivenNoSerializerThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ISerializer? serializer = default;

        // Act
        Func<ICloner> act = () => new DefaultCloner(serializer!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(serializer));
    }
}