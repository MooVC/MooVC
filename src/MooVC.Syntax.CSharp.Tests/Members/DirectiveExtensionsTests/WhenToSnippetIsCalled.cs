namespace MooVC.Syntax.CSharp.Members.DirectiveExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string Alias = "Collections";
    private const string CustomQualifier = "MooVC.Syntax";
    private const string SystemQualifier = "System";

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Directive> directives = isDefault
            ? default
            : [];

        // Act
        var snippet = directives.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Directive> directives = [Create(SystemQualifier)];
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = directives.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedCorrectly()
    {
        // Arrange
        Directive alias = Create(CustomQualifier, alias: Alias);
        Directive @using = Create(CustomQualifier);
        Directive system = Create(SystemQualifier);
        Directive @static = Create($"{SystemQualifier}.Console", isStatic: true);

        ImmutableArray<Directive> directives = [@static, system, @using, alias];

        const string expected = """
            using System;
            using MooVC.Syntax;
            using Collections = MooVC.Syntax;
            using static System.Console;
            """;

        // Act
        var snippet = directives.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }

    private static Directive Create(string qualifier, string? alias = default, bool isStatic = false)
    {
        return new Directive
        {
            Alias = alias is null ? Name.Unnamed : new Name(alias),
            IsStatic = isStatic,
            Qualifier = qualifier,
        };
    }
}