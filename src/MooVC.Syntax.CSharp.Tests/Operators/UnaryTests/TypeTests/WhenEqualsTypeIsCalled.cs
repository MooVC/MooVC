namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(null as Unary.Type);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(type);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(Unary.Type.Increment);

        // Assert
        result.ShouldBeFalse();
    }
}