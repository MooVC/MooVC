namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenWithGetIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var get = Snippet.From("result");

        // Act
        Indexer.Methods result = original.WithGet(get);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Get).IsEqualTo(get);
        _ = await Assert.That(result.Set).IsEqualTo(original.Set);
        _ = await Assert.That(original.Get).IsEqualTo(Snippet.Empty);
    }
}