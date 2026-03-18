namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(default(Conversion.Type));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(type);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Conversion.Type.Implicit);

        // Assert
        result.ShouldBeFalse();
    }
}