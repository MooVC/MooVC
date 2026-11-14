namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenBehavioursWhenInlineIsLambdaThenBodyIsRendered()
    {
        // Arrange
        var methods = new Indexer.Methods
        {
            Get = Snippet.From("value;"),
        };

        Indexer subject = IndexerTestsData.Create(behaviours: methods);

        // Act
        string representation = subject.ToSnippet(Indexer.Options.Default);

        // Assert
        string expected = "public string this[int index] { get => value; }";

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenBehavioursWhenInlineIsMutipleLineBracesThenBodyIsRendered()
    {
        // Arrange
        var methods = new Indexer.Methods
        {
            Get = Snippet.From("return value;"),
        };

        Indexer subject = IndexerTestsData.Create(behaviours: methods);

        Indexer.Options options = Indexer.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.Options.Blocks.Styles.MultiLine)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        string expected = """
            public string this[int index]
            {
                get
                {
                    return value;
                }
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenBehavioursWhenInlineIsSingleLineBracesThenBodyIsRendered()
    {
        // Arrange
        var methods = new Indexer.Methods
        {
            Get = Snippet.From("return value;"),
        };

        Indexer subject = IndexerTestsData.Create(behaviours: methods);

        Indexer.Options options = Indexer.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.Options.Blocks.Styles.SingleLine)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        string expected = "public string this[int index] { get { return value; } }";

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenExplicitInterfaceAndMultipleParametersThenQualifiedIndexerIsRendered()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(behaviours: Indexer.Methods.Default
            .HasGetter(false)
            .WithSet("values[row, column] = value;"))
            .WithExplicitInterface(Symbol.Undefined.Named(("IContract", "Example")))
            .Accepts(
                Parameter.Undefined.Named("row").OfType(typeof(int)),
                Parameter.Undefined.Named("column").OfType(typeof(int)));

        Indexer.Options options = Indexer.Options.Default
            .WithQualifications(qualifications => qualifications.WithFormat(Qualification.Options.Formats.Global))
            .WithSnippets(snippets => snippets.WithBlock(block => block.WithInline(Snippet.Options.Blocks.Styles.MultiLine)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        const string expected = """
            string global::Example.IContract.this[int row, int column]
            {
                set
                {
                    values[row, column] = value;
                }
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenRestrictedSetterThenSetterScopeIsRendered()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(behaviours: Indexer.Methods.Default
            .WithGet("return values[index];")
            .WithSet("values[index] = value;")
            .WithSetterScope(Scopes.Internal));

        Indexer.Options options = Indexer.Options.Default
            .WithSnippets(snippets => snippets.WithBlock(block => block.WithInline(Snippet.Options.Blocks.Styles.MultiLine)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(representation).Contains("internal set");
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}