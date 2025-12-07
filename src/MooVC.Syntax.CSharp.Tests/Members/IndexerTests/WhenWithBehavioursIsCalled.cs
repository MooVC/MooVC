namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenWithBehavioursIsCalled
{
    [Fact]
    public void GivenBehavioursThenReturnsNewInstanceWithUpdatedBehaviours()
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
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(behaviours);
        result.Parameter.ShouldBe(original.Parameter);
        result.Result.ShouldBe(original.Result);
        result.Scope.ShouldBe(original.Scope);
    }
}
