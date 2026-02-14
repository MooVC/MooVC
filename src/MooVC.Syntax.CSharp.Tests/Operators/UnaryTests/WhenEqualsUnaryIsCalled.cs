namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsUnaryIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Unary? subject = default;
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create(@operator: Unary.Type.Minus);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}