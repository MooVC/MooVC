namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(default(Comparison.Type));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(type);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Comparison.Type.Equality);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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