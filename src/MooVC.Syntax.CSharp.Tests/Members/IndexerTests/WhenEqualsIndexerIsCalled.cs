namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsIndexerIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Indexer? subject = default;
        Indexer target = IndexerTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create(parameter: new Parameter { Name = "alternative" });

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentBehavioursThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        Indexer target = IndexerTestsData.Create(
            behaviours: new Indexer.Methods
            {
                Get = Snippet.From("value"),
            });

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentResultsThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        Indexer target = IndexerTestsData.Create(
            result: new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = "int" },
            });

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}