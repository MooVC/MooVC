namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAutoImplementedMembersThenReturnsReadOnlyProperty()
    {
        // Arrange
        var subject = new Indexer.Methods();
        const string expected = "get;";

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenDefaultInstanceThenReturnsReadOnlyProperty()
    {
        // Arrange
        Indexer.Methods subject = Indexer.Methods.Default;
        const string expected = "get;";

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenExpressionBodiesThenReturnsExpressions()
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
        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenMultiLineBodyThenReturnsBlock()
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
        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}