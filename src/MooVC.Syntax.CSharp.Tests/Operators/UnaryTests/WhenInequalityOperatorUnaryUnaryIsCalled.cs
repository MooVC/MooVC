namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenInequalityOperatorUnaryUnaryIsCalled
{
    [Test]
    public async Task GivenEquivalentUnaryOperatorsThenReturnsFalse()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentUnaryOperatorsThenReturnsTrue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create(@operator: Unary.Type.Decrement);

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}