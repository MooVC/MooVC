namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenDefaultInstanceThenReturnsEmpty()
    {
        // Arrange
        Indexer.Methods subject = Indexer.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenAutoImplementedMembersThenReturnsEmpty()
    {
        // Arrange
        var subject = new Indexer.Methods();

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBeEmpty();
    }

    [Fact]
    public void GivenExpressionBodiesThenReturnsExpressions()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value;"),
        };

        string expected = "get => value;";

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultiLineBodyThenReturnsBlock()
    {
        // Arrange
        var get = Snippet.From($"first{Environment.NewLine}second");

        var subject = new Indexer.Methods
        {
            Get = get,
        };

        string expected = """
            get
            {
                first
                second
            }
            """;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(expected);
    }
}