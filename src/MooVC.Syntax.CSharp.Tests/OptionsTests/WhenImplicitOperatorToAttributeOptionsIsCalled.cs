namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToAttributeOptionsIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Attribute.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenExplicitTypeAttributesThenOverridesArePreserved()
    {
        // Arrange
        const string whitespace = "\t";
        Snippet.Options snippets = Snippet.Options.Default.WithWhitespace(whitespace);
        Qualification.Options qualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Attribute.Options expected = Attribute.Options.Inline
            .WithQualifications(qualifications)
            .WithSnippets(snippets);
        Options subject = Options.Default.WithTypes(types => types
            .WithAttributes(expected)
            .WithMethods(methods => methods.WithAttributes(Attribute.Options.Separate)));

        // Act
        Attribute.Options result = subject;

        // Assert
        _ = await Assert.That(result).IsSameReferenceAs(expected);
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenUnspecifiedAttributeSettingsThenParentSettingsAreInherited(bool useTypeSnippets)
    {
        // Arrange
        const string topLevelWhitespace = "\t";
        const string typeWhitespace = "  ";
        Snippet.Options topLevelSnippets = Snippet.Options.Default.WithWhitespace(topLevelWhitespace);
        Snippet.Options typeSnippets = Snippet.Options.Default.WithWhitespace(typeWhitespace);
        Qualification.Options qualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Attribute.Options attributes = Attribute.Options.Inline;
        Options subject = Options.Default
            .WithSnippets(topLevelSnippets)
            .WithTypes(types => types
                .WithAttributes(attributes)
                .WithQualifications(qualifications)
                .WithSnippets(useTypeSnippets ? typeSnippets : Snippet.Options.Unspecified));
        Snippet.Options expectedSnippets = useTypeSnippets ? typeSnippets : topLevelSnippets;

        // Act
        Attribute.Options result = subject;

        // Assert
        _ = await Assert.That(result.Format).IsSameReferenceAs(Attribute.Options.Styles.Inline);
        _ = await Assert.That(result.Qualifications).IsSameReferenceAs(qualifications);
        _ = await Assert.That(result.Snippets).IsSameReferenceAs(expectedSnippets);
        _ = await Assert.That(attributes.Qualifications).IsSameReferenceAs(Qualification.Options.Unspecified);
        _ = await Assert.That(attributes.Snippets).IsSameReferenceAs(Snippet.Options.Unspecified);
        _ = await Assert.That(subject.Types.Attributes).IsSameReferenceAs(attributes);
    }
}