namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenEqualityOperatorTypeStringIsCalled
{
    private const string Same = "==";
    private const string Different = "!=";

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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