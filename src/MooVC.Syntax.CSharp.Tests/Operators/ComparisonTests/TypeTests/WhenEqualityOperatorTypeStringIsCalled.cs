namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualityOperatorTypeStringIsCalled
{
    private const string Same = "==";
    private const string Different = "!=";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Comparison.Type? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Comparison.Type? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.Equality;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.Equality;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Comparison.Type left = Comparison.Type.Equality;
        string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}