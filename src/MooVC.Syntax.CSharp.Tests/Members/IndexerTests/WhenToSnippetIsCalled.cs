namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenBehavioursWhenInlineIsLambdaThenBodyIsRendered()
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

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenBehavioursWhenInlineIsSingleLineBracesThenBodyIsRendered()
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

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenBehavioursWhenInlineIsMutipleLineBracesThenBodyIsRendered()
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

        representation.ShouldBe(expected);
    }
}