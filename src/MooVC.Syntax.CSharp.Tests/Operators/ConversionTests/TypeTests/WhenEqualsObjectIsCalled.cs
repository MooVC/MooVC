namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Conversion.Type.Implicit as object);

        // Assert
        result.ShouldBeFalse();
    }
}
