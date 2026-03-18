namespace MooVC.Syntax.Elements.QualifierExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstQualifier = "MooVC.Sandbox";
    private const string SecondQualifier = "MooVC.Core";

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Qualifier> qualifiers = isDefault
            ? default
            : [];

        // Act
        var snippet = qualifiers.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Qualifier> qualifiers = [FirstQualifier];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = qualifiers.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedAlphabetically()
    {
        // Arrange
        ImmutableArray<Qualifier> qualifiers = [FirstQualifier, SecondQualifier];

        const string expected = """
            MooVC.Core
            MooVC.Sandbox
            """;

        // Act
        var snippet = qualifiers.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}