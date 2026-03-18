namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenWithOperatorIsCalled
{
    [Test]
    public async Task GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        Comparison.Type replacement = Comparison.Type.LessThan;

        // Act
        Comparison result = original.WithOperator(replacement);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Operator).IsEqualTo(replacement);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}