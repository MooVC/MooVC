namespace MooVC.Syntax.CSharp.UnaryTests;

public sealed class WhenEqualityOperatorUnaryUnaryIsCalled
{
    [Test]
    public async Task GivenEquivalentUnaryOperatorsThenReturnsTrue()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentUnaryOperatorsThenReturnsFalse()
    {
        // Arrange
        Unary first = UnaryTestsData.Create();
        Unary second = UnaryTestsData.Create(@operator: Unary.Type.Decrement);

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}