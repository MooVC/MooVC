namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();
        var body = Snippet.From("Shutdown();");

        // Act
        Constructor result = original.WithBody(body);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(body);
        result.Extensibility.ShouldBe(original.Extensibility);
        result.Parameters.ShouldBe(original.Parameters);
        result.Scope.ShouldBe(original.Scope);

        original.Body.ShouldBe(Snippet.From("Initialize();"));
    }
}