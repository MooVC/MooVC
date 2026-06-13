namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenWithSetIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var set = Snippet.From("result");

        // Act
        Indexer.Methods result = original.WithSet(set);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Get).IsEqualTo(original.Get);
        _ = await Assert.That(result.Set).IsEqualTo(set);
        _ = await Assert.That(original.Set).IsEqualTo(Snippet.Empty);
    }
}