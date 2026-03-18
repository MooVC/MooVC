namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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