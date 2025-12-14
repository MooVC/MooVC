namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenWithOperatorIsCalled
{
    [Fact]
    public void GivenOperatorThenReturnsNewInstanceWithUpdatedOperator()
    {
        // Arrange
        Unary original = UnaryTestsData.Create();
        Unary.Type replacement = Unary.Type.Decrement;

        // Act
        Unary result = original.WithOperator(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Operator.ShouldBe(replacement);
        result.Scope.ShouldBe(original.Scope);
    }
}
