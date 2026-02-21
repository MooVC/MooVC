namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Unary original = UnaryTestsData.Create(body: Snippet.From("return value;"));
        var replacement = "return other;";

        // Act
        Unary result = original.WithBody(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(replacement);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(original.Scope);
    }
}