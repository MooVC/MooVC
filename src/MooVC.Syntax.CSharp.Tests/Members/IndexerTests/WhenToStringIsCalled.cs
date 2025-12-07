namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenToStringIsCalled
{
    private const string GetBody = "value";
    private const string SetBody = "value = input";

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
    public void GivenDefaultBehavioursThenSignatureIsBlocked()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            {
                public string [int index]
            }
            """;

        representation.ShouldBe(expected.ToString());
    }

    [Fact]
    public void GivenBehavioursThenBodyIsRendered()
    {
        // Arrange
        var methods = new Indexer.Methods
        {
            Get = Snippet.From(GetBody),
            Set = Snippet.From(SetBody),
        };

        Indexer subject = IndexerTestsData.Create(behaviours: methods);

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            get => value;
            set => value = input;
            {
                public string [int index]
            }
            """;

        representation.ShouldBe(expected.ToString());
    }
}
