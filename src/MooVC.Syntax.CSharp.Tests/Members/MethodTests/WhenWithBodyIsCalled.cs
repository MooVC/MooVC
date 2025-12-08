namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Method original = MethodTestsData.Create(body: Snippet.From("return value;"));
        Snippet replacement = Snippet.From("return other;");

        // Act
        Method result = original.WithBody(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(replacement);
        result.Name.ShouldBe(original.Name);
        result.Parameters.ShouldBe(original.Parameters);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
    }
}
