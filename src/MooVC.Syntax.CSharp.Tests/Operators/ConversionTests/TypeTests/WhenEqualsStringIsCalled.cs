namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "explicit";
    private const string Other = "implicit";

    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Value);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        bool result = type.Equals(Other);

        // Assert
        result.ShouldBeFalse();
    }
}