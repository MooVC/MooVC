namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToPropertyOptionsIsCalled
{
    [Test]
    public async Task GivenExplicitMemberOptionsThenOverridesArePreserved()
    {
        // Arrange
        const string whitespace = "\t";
        Snippet.Options snippets = Snippet.Options.Default.WithWhitespace(whitespace);
        Qualification.Options qualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Property.Options expected = Property.Options.Default
            .WithImplied(Scopes.Public)
            .WithQualifications(qualifications)
            .WithSnippets(snippets);
        Options subject = Options.Default.WithTypes(types => types.WithProperties(expected));

        // Act
        Property.Options result = subject;

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
        Qualification.Options qualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Property.Options memberOptions = Property.Options.Default.WithSnippets(Snippet.Options.Unspecified);
        Type.Options types = Type.Options.Default
            .WithProperties(memberOptions)
            .WithQualifications(qualifications)
            .WithSnippets(useTypeSnippets ? typeSnippets : Snippet.Options.Unspecified);
        Options subject = Options.Default.WithSnippets(topLevelSnippets).WithTypes(types);
        Snippet.Options expected = useTypeSnippets ? typeSnippets : topLevelSnippets;

        // Act
        Property.Options result = subject;

        // Assert
        _ = await Assert.That(result.Snippets).IsSameReferenceAs(expected);
        _ = await Assert.That(result.Qualifications).IsSameReferenceAs(qualifications);
        _ = await Assert.That(memberOptions.Snippets).IsSameReferenceAs(Snippet.Options.Unspecified);
        _ = await Assert.That(subject.Types).IsSameReferenceAs(types);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Property.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}