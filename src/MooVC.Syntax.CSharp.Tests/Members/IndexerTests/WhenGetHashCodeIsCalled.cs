namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create(parameter: new Parameter { Name = "alternative" });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentBehavioursThenHashesDiffer()
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
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentResultsThenHashesDiffer()
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
        firstHash.ShouldNotBe(secondHash);
    }
}
