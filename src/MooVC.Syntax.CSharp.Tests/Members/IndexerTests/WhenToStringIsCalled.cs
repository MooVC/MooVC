namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedIndexerThenEmptyReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenDefaultBehavioursThenEmptyReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
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
        string representation = subject.ToString(options);

        // Assert
        string expected = "public string this[int index] => get => value;";

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
        string representation = subject.ToString(options);

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
        string representation = subject.ToString(options);

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

    [Fact]
    public void GivenBehavioursWhenGetAndSetThenBodyIsRendered()
    {
        // Arrange
        var methods = new Indexer.Methods
        {
            Get = Snippet.From("value;"),
            Set = Snippet.From("_value[index] = value;"),
        };

        Indexer subject = IndexerTestsData.Create(behaviours: methods);

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            public string this[int index]
            {
                get => value;
                set => _value[index] = value;
            }
            """;

        representation.ShouldBe(expected);
    }
}