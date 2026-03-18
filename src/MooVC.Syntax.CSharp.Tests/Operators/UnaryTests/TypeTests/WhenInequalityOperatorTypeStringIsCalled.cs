namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenInequalityOperatorTypeStringIsCalled
{
    private const string Same = "!";
    private const string Different = "++";

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Type? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Unary.Type? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Unary.Type left = Unary.Type.Not;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Unary.Type left = Unary.Type.Not;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Unary.Type left = Unary.Type.Not;
        string right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}