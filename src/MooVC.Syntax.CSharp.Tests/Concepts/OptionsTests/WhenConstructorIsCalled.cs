namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements.Chaining;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public void GivenDefaultsThenValuesAreInitialized()
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
        @namespace.ShouldBe(Qualifier.Options.File);
        snippets.ShouldBe(expected);
    }
}