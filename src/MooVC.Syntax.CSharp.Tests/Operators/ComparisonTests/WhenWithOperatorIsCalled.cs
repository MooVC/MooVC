namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenWithOperatorIsCalled
{
    [Fact]
    public void GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        Comparison.Type replacement = Comparison.Type.LessThan;

        // Act
        Comparison result = original.WithOperator(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(replacement);
        result.Scope.ShouldBe(original.Scope);
    }
}