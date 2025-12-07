namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithResultIsCalled
{
    [Fact]
    public void GivenResultThenReturnsNewInstanceWithUpdatedResult()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();
        var result = new Result
        {
            Mode = Result.Modality.Asynchronous,
            Type = typeof(int),
        };

        // Act
        Indexer instance = original.WithResult(result);

        // Assert
        instance.ShouldNotBeSameAs(original);
        instance.Parameter.ShouldBe(original.Parameter);
        instance.Result.ShouldBe(result);
        instance.Scope.ShouldBe(original.Scope);
    }
}
