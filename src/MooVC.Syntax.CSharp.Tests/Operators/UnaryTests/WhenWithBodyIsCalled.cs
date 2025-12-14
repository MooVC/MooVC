namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Unary original = UnaryTestsData.Create(body: Snippet.From("return value;"));
        var replacement = Snippet.From("return other;");

        // Act
        Unary result = original.WithBody(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(replacement);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(original.Scope);
    }
}