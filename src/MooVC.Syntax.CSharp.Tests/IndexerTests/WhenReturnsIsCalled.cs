namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenReturnsIsCalled
{
    [Test]
    public async Task GivenResultThenReturnsNewInstanceWithUpdatedResult()
    {
        // Arrange
        Indexer original = IndexerTestsData.Create();

        var result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new() { Name = "int" },
        };

        // Act
        Indexer updated = original.Returns(result);

        // Assert
        _ = await Assert.That(updated).IsNotSameReferenceAs(original);
        _ = await Assert.That(updated.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(updated.Parameter).IsEqualTo(original.Parameter);
        _ = await Assert.That(updated.Result).IsEqualTo(result);
        _ = await Assert.That(updated.Scope).IsEqualTo(original.Scope);
    }
}