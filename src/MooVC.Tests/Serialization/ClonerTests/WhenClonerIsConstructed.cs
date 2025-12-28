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
        _ = cloner.ShouldNotBeNull();
    }

    [Fact]
    public void GivenNoSerializerThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ISerializer? serializer = default;

        // Act
        Func<ICloner> act = () => new Cloner(serializer!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(serializer));
    }
}