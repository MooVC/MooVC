namespace MooVC.Syntax.CSharp.Members.IndexerExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Indexer> indexers = isDefault
            ? default
            : [];

        // Act
        var snippet = indexers.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Indexer> indexers = [IndexerTestsData.Create()];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = indexers.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedByScopeExtensibilityParameterAndResult()
    {
        // Arrange
        Indexer publicVirtual = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Beta" },
            result: new Result { Type = new Symbol { Name = "int" } });

        Indexer publicStatic = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Alpha" },
            result: new Result { Type = new Symbol { Name = "string" } });

        Indexer protectedVirtual = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Gamma" },
            result: new Result { Type = new Symbol { Name = "int" } },
            scope: Scope.Protected);

        publicVirtual.Extensibility = Extensibility.Virtual;
        publicStatic.Extensibility = Extensibility.Static;
        protectedVirtual.Extensibility = Extensibility.Virtual;

        ImmutableArray<Indexer> indexers =
        [
            protectedVirtual,
            publicVirtual,
            publicStatic,
        ];

        const string expected = """
            public static string this[Version alpha]
            {
                get;
                set;
            }

            public virtual int this[Version beta]
            {
                get;
                set;
            }

            protected virtual int this[Version gamma]
            {
                get;
                set;
            }
            """;

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        var snippet = indexers.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}