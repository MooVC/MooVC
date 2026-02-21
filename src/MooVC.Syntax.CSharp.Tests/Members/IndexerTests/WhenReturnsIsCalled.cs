namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenReturnsIsCalled
{
    [Fact]
    public void GivenResultThenReturnsNewInstanceWithUpdatedResult()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();

        var result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = "int" },
        };

        // Act
        Indexer updated = original.Returns(result);

        // Assert
        updated.ShouldNotBeSameAs(original);
        updated.Behaviours.ShouldBe(original.Behaviours);
        updated.Parameter.ShouldBe(original.Parameter);
        updated.Result.ShouldBe(result);
        updated.Scope.ShouldBe(original.Scope);
    }
}