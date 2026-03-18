namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Get).IsEqualTo(original.Get);
        await Assert.That(result.Set).IsEqualTo(set);
        await Assert.That(original.Set).IsEqualTo(Snippet.Empty);
    }
}