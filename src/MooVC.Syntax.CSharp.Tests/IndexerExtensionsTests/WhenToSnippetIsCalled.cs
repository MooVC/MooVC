namespace MooVC.Syntax.CSharp.IndexerExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Indexer> indexers = isDefault
            ? default
            : [];

        // Act
        var snippet = indexers.ToSnippet(Indexer.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Indexer> indexers = [IndexerTestsData.Create()];
        Indexer.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = indexers.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByScopeExtensibilityParameterAndResult()
    {
        // Arrange
        Indexer publicVirtual = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Beta", Type = typeof(Version) },
            result: new Result { Type = new() { Name = "int" } });

        Indexer publicStatic = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Alpha", Type = typeof(Version) },
            result: new Result { Type = new() { Name = "string" } });

        Indexer protectedVirtual = IndexerTestsData.Create(
            parameter: new Parameter { Name = "Gamma", Type = typeof(Version) },
            result: new Result { Type = new() { Name = "int" } },
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
            public static string this[Version alpha] { get; }

            public virtual int this[Version beta] { get; }

            protected virtual int this[Version gamma] { get; }
            """;

        // Act
        var snippet = indexers.ToSnippet(Indexer.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}