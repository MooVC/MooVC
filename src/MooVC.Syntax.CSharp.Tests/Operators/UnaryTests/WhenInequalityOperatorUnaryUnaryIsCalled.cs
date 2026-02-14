namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenInequalityOperatorUnaryUnaryIsCalled
{
    [Fact]
    public void GivenEquivalentUnaryOperatorsThenReturnsFalse()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentUnaryOperatorsThenReturnsTrue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create(@operator: Unary.Type.Decrement);

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeTrue();
    }
}