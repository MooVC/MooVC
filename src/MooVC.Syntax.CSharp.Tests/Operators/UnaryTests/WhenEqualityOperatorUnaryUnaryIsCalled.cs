namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualityOperatorUnaryUnaryIsCalled
{
    [Test]
    public void GivenEquivalentUnaryOperatorsThenReturnsTrue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentUnaryOperatorsThenReturnsFalse()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create(@operator: Unary.Type.Decrement);

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeFalse();
    }
}