namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Get).IsEqualTo(get);
        await Assert.That(result.Set).IsEqualTo(original.Set);
        await Assert.That(original.Get).IsEqualTo(Snippet.Empty);
    }
}