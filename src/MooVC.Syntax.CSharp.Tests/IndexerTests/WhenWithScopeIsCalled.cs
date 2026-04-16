namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create(scope: Scopes.Internal);

        // Act
        Indexer result = original.WithScope(Scopes.Private);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Parameter).IsEqualTo(original.Parameter);
        _ = await Assert.That(result.Result).IsEqualTo(original.Result);
        _ = await Assert.That(result.Scope).IsEqualTo(Scopes.Private);
    }
}