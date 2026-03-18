namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedIndexerThenEmptyReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenDefaultBehavioursThenEmptyReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenBehavioursWhenGetAndSetThenBodyIsRendered()
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

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}