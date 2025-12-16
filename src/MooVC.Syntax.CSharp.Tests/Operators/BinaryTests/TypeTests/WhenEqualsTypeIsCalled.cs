namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(null as Binary.Type);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(type);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Binary.Type.Subtract);

        // Assert
        result.ShouldBeFalse();
    }
}
