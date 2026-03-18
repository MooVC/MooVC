namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenWithOperatorIsCalled
{
    [Test]
    public async Task GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Unary original = UnaryTestsData.Create();
        Unary.Type replacement = Unary.Type.Decrement;

        // Act
        Unary result = original.WithOperator(replacement);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Operator).IsEqualTo(replacement);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}