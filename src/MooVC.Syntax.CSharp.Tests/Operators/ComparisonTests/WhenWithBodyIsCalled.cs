namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        Snippet body = Snippet.From("return left != right;");

        // Act
        Comparison result = original.WithBody(body);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(original.Scope);
    }
}
