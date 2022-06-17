namespace MooVC.Serialization.DefaultClonerTests;

using System;
using Moq;
using Xunit;

public sealed class WhenDefaultClonerIsConstructed
{
    [Fact]
    public void GivenASerializerThenAnInstanceIsReturned()
    {
        var serializer = new Mock<ISerializer>();

        _ = new DefaultCloner(serializer.Object);
    }

    [Fact]
    public void GivenNoSerializerThenAnArgumentNullExceptionIsThrown()
    {
        ISerializer? serializer = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new DefaultCloner(serializer!));

        Assert.Equal(nameof(serializer), exception.ParamName);
    }
}