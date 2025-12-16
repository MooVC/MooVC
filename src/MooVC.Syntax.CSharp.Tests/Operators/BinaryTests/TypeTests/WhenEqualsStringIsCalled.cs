namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "+";
    private const string Other = "-";

    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Value);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Other);

        // Assert
        result.ShouldBeFalse();
    }
}
