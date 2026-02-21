namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenMethodThenSnippetIsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        Snippet snippet = subject;

        // Assert
        snippet.ShouldBe(Snippet.From(subject.ToString()));
    }
}