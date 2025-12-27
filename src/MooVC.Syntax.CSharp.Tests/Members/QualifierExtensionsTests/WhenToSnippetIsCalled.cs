namespace MooVC.Syntax.CSharp.Members.QualifierExtensionsTests;

using System;
using System.Collections.Immutable;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstQualifier = "MooVC.Sandbox";
    private const string SecondQualifier = "MooVC.Core";

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Qualifier> qualifiers = isDefault
            ? default
            : [];

        // Act
        var snippet = qualifiers.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Qualifier> qualifiers = [FirstQualifier];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = qualifiers.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedAlphabetically()
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
        snippet.ToString().ShouldBe(expected);
    }
}