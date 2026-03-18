namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehavioursIsCalled
{
    [Test]
    public async Task GivenBehavioursThenReturnsNewInstanceWithUpdatedBehaviours()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();

        var behaviours = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        Indexer result = original.WithBehaviours(behaviours);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(result.Parameter).IsEqualTo(original.Parameter);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}