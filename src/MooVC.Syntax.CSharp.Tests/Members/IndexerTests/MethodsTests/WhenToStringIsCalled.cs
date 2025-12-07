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
            Get = Snippet.From("value"),
            Set = Snippet.Empty,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = Snippet.From($"get => {subject.Get};")
            .Append(Snippet.Options.Default, Environment.NewLine)
            .Append("set;")
            .ToString();

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

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = get
            .Block(Snippet.Options.Default, opening: Snippet.From("get"))
            .Append(Snippet.Options.Default, Environment.NewLine)
            .Append("set;")
            .ToString();

        representation.ShouldBe(expected);
    }
}