namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        Indexer result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Parameter.ShouldBe(original.Parameter);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(Scope.Private);
    }
}
