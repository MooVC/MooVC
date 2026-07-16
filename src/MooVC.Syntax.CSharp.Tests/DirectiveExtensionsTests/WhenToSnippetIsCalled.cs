namespace MooVC.Syntax.CSharp.DirectiveExtensionsTests;

using System;
using System.Collections.Immutable;

public sealed class WhenToSnippetIsCalled
{
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
        ImmutableArray<Directive> directives = [Create("System")];
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
        Directive alias1 = Create("System.Collections", alias: "Collections");
        Directive alias2 = Create("MooVC.Syntax", alias: "Syntax");
        Directive @using = Create("Mu.Modelling.State");
        Directive system1 = Create("System");
        Directive system2 = Create("System.Collections.Immutable");
        Directive system3 = Create("System.ComponentModel");
        Directive @static = Create("System.Console", isStatic: true);

        ImmutableArray<Directive> directives = [@static, system3, system2, system1, alias2, alias1, @using];

        const string expected = """
            using System;
            using System.Collections.Immutable;
            using System.ComponentModel;
            using Mu.Modelling.State;
            using Collections = System.Collections;
            using Syntax = MooVC.Syntax;
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