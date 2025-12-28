namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenValuesAreInitialized()
    {
        // Arrange
        var subject = new Options();

        // Act
        Qualifier.Options namespaceOption = subject.Namespace;
        Snippet.Options snippets = subject.Snippets;

        // Assert
        namespaceOption.ShouldBe(Qualifier.Options.File);
        snippets.ShouldBe(Snippet.Options.Default);
    }
}