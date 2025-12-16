namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Equality as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Inequality as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenAnUnrecognisedTypeThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }
}