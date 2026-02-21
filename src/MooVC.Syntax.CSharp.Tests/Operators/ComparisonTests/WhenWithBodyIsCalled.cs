namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Comparison original = ComparisonTestsData.Create();
        var body = "return left != right;";

        // Act
        Comparison result = original.WithBody(body);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(original.Scope);
    }
}