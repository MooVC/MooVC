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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        await Assert.That(result.Parameter).IsEqualTo(original.Parameter);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
    }
}