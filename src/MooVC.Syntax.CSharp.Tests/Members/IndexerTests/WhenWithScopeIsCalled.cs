namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        Indexer result = original.WithScope(Scope.Private);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Parameter).IsEqualTo(original.Parameter);
        await Assert.That(result.Result).IsEqualTo(original.Result);
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);
    }
}