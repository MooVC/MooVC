namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Binary.Type.Subtract as object);

        // Assert
        result.ShouldBeFalse();
    }
}
