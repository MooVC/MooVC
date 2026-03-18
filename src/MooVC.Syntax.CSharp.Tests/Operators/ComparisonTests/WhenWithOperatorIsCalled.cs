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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Operator).IsEqualTo(replacement);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}