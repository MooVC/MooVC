namespace MooVC.Syntax.CSharp.OptionsTests;

using MooVC.Syntax.CSharp.Chaining;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenValuesAreInitialized()
    {
        // Arrange
        var subject = new Options();

        Snippet.Options expected = Snippet.Options.Default.WithChaining(new[]
        {
            OneDotPerLine.Instance,
            Parentheses.Instance,
        });

        // Act
        Qualifier.Options @namespace = subject.Namespace;
        Snippet.Options snippets = subject.Snippets;

        // Assert
        _ = await Assert.That(@namespace).IsEqualTo(Qualifier.Options.File);
        _ = await Assert.That(snippets).IsEqualTo(expected);
    }
}