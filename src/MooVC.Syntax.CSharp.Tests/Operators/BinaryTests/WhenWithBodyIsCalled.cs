namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Binary original = BinaryTestsData.Create();
        var body = Snippet.From("return left * right;");

        // Act
        Binary result = original.WithBody(body);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(body);
        result.Operator.ShouldBe(original.Operator);
        result.Scope.ShouldBe(original.Scope);
    }
}