namespace MooVC.Serialization.DefaultClonerTests;

using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

public sealed class WhenDefaultClonerIsConstructed
{
    [Fact]
    public void GivenASerializerThenAnInstanceIsReturned()
    {
        // Arrange
        ISerializer serializer = Substitute.For<ISerializer>();

        // Act
        var cloner = new DefaultCloner(serializer);

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