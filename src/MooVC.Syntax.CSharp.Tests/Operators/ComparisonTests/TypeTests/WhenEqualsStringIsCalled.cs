namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "==";
    private const string Other = "!=";

    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        bool result = type.Equals(Other);

        // Assert
        result.ShouldBeFalse();
    }
}