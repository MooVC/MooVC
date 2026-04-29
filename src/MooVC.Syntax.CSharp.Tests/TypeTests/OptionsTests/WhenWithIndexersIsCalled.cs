namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Indexer.Options value = Indexer.Options.Default.WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        Type.Options result = options.WithIndexers(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Indexers).IsEqualTo(value);
        _ = await Assert.That(options.Indexers).IsNotEqualTo(value);
    }
}