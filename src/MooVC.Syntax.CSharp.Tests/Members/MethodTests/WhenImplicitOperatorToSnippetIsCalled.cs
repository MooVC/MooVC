namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenMethodThenSnippetIsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        Snippet snippet = subject;

        // Assert
        await Assert.That(snippet).IsEqualTo(Snippet.From(subject.ToString()));
    }
}