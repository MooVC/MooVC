namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

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
                    .WithInline(inline => inline.WithProperties(Snippet.BlockOptions.InlineStyle.SingleLineBraces))));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        string expected = "public string this[int index] { get { return value; } }";

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
                    .WithInline(inline => inline.WithProperties(Snippet.BlockOptions.InlineStyle.MultiLineBraces))));

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
}