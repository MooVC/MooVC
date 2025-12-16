namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(null as Comparison.Type);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(type);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Equality);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Inequality);

        // Assert
        result.ShouldBeFalse();
    }
}
