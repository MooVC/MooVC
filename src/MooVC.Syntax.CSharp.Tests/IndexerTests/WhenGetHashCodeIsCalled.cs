namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentBehavioursThenHashesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();

        Indexer second = IndexerTestsData.Create(
            behaviours: new Indexer.Methods
            {
                Get = Snippet.From("value"),
            });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentResultsThenHashesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();

        Indexer second = IndexerTestsData.Create(
            result: new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = "int" },
            });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create(parameter: new Parameter { Name = "alternative" });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}