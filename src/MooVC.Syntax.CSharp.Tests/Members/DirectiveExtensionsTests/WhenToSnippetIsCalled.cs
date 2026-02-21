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

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Directive> directives = isDefault
            ? default
            : [];

        // Act
        var snippet = directives.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Directive> directives = [Create(SystemQualifier)];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = directives.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedCorrectly()
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
        snippet.ToString().ShouldBe(expected);
    }

    private static Directive Create(string qualifier, string? alias = default, bool isStatic = false)
    {
        return new Directive
        {
            Alias = alias is null ? Name.Unnamed : alias,
            IsStatic = isStatic,
            Qualifier = qualifier,
        };
    }
}