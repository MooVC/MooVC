namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToEventOptionsIsCalled
{
    [Test]
    public async Task GivenExplicitMemberOptionsThenOverridesArePreserved()
    {
        // Arrange
        const string whitespace = "\t";
        Snippet.Options snippets = Snippet.Options.Default.WithWhitespace(whitespace);
        Event.Options expected = Event.Options.Default
            .WithImplied(Scopes.Public)
            .WithSnippets(snippets);
        Options subject = Options.Default.WithTypes(types => types.WithEvents(expected));

        // Act
        Event.Options result = subject;

        // Assert
        _ = await Assert.That(result).IsSameReferenceAs(expected);
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenUnspecifiedMemberSnippetsThenParentSnippetsAreInherited(bool useTypeSnippets)
    {
        // Arrange
        const string topLevelWhitespace = "\t";
        const string typeWhitespace = "  ";
        Snippet.Options topLevelSnippets = Snippet.Options.Default.WithWhitespace(topLevelWhitespace);
        Snippet.Options typeSnippets = Snippet.Options.Default.WithWhitespace(typeWhitespace);
        Event.Options memberOptions = Event.Options.Default.WithSnippets(Snippet.Options.Unspecified);
        Type.Options types = Type.Options.Default
            .WithEvents(memberOptions)
            .WithSnippets(useTypeSnippets ? typeSnippets : Snippet.Options.Unspecified);
        Options subject = Options.Default.WithSnippets(topLevelSnippets).WithTypes(types);
        Snippet.Options expected = useTypeSnippets ? typeSnippets : topLevelSnippets;

        // Act
        Event.Options result = subject;

        // Assert
        _ = await Assert.That(result.Snippets).IsSameReferenceAs(expected);
        _ = await Assert.That(memberOptions.Snippets).IsSameReferenceAs(Snippet.Options.Unspecified);
        _ = await Assert.That(subject.Types).IsSameReferenceAs(types);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Event.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}