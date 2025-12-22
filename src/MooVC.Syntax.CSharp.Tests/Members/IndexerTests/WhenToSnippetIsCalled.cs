namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Snippet.Options? options = default;

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

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));

        // Act
        string representation = subject.ToSnippet(options);

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

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.SingleLineBraces));

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

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

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