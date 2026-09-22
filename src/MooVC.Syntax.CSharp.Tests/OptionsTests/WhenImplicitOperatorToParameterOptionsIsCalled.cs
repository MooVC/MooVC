namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenImplicitOperatorToParameterOptionsIsCalled
{
    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenMethodOptionsThenInheritedSettingsAreUsed(bool useMethodOverrides)
    {
        // Arrange
        const string topLevelWhitespace = "\t";
        const string methodWhitespace = "  ";
        Snippet.Options topLevelSnippets = Snippet.Options.Default.WithWhitespace(topLevelWhitespace);
        Snippet.Options methodSnippets = Snippet.Options.Default.WithWhitespace(methodWhitespace);
        Qualification.Options typeQualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Global);
        Qualification.Options methodQualifications = Qualification.Options.Default.WithFormat(Qualification.Options.Formats.Full);
        Method.Options methods = Method.Options.Default
            .WithQualifications(useMethodOverrides ? methodQualifications : Qualification.Options.Unspecified)
            .WithSnippets(useMethodOverrides ? methodSnippets : Snippet.Options.Unspecified);
        Options subject = Options.Default
            .WithSnippets(topLevelSnippets)
            .WithTypes(types => types.WithMethods(methods).WithQualifications(typeQualifications));
        Qualification.Options expectedQualifications = useMethodOverrides ? methodQualifications : typeQualifications;
        Snippet.Options expectedSnippets = useMethodOverrides ? methodSnippets : topLevelSnippets;

        // Act
        Parameter.Options result = subject;

        // Assert
        _ = await Assert.That(result.Qualifications).IsSameReferenceAs(expectedQualifications);
        _ = await Assert.That(result.Snippets).IsSameReferenceAs(expectedSnippets);
        _ = await Assert.That(result.Naming).IsSameReferenceAs(Variable.Options.Camel);
        _ = await Assert.That(subject.Types.Methods).IsSameReferenceAs(methods);
    }

    [Test]
    public async Task GivenNullOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options? subject = default;

        // Act
        Func<Parameter.Options> act = () => subject!;

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }
}