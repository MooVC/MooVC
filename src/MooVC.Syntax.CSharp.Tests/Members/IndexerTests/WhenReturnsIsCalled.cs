namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

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
            Type = new Symbol { Name = "int" },
        };

        // Act
        Indexer updated = original.Returns(result);

        // Assert
        await Assert.That(ReferenceEquals(updated, original)).IsFalse();
        await Assert.That(updated.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(updated.Parameter).IsEqualTo(original.Parameter);
        await Assert.That(updated.Result).IsEqualTo(result);
        await Assert.That(updated.Scope).IsEqualTo(original.Scope);
    }
}