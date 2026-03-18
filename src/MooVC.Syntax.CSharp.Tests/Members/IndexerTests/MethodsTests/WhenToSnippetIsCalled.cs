namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("get => value"),
        };

        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}