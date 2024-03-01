namespace MooVC.Serialization.ClonerTests;

public sealed class WhenClonerIsConstructed
{
    [Fact]
    public void GivenASerializerThenAnInstanceIsReturned()
    {
        // Arrange
        ISerializer serializer = Substitute.For<ISerializer>();

        // Act
        var cloner = new Cloner(serializer);

        // Assert
        _ = cloner.Should().NotBeNull();
    }

    [Fact]
    public void GivenNoSerializerThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ISerializer? serializer = default;

        // Act
        Func<ICloner> act = () => new Cloner(serializer!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(serializer));
    }
}