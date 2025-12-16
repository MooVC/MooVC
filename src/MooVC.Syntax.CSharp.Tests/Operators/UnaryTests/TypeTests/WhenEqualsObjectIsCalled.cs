namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(Unary.Type.Increment as object);

        // Assert
        result.ShouldBeFalse();
    }
}
