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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Operator).IsEqualTo(replacement);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}