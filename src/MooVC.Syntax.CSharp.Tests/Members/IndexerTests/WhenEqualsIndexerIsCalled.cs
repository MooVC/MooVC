namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsIndexerIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Indexer? subject = default;
        Indexer target = IndexerTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create(parameter: new Parameter { Name = "alternative" });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentBehavioursThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        Indexer target = IndexerTestsData.Create(
            behaviours: new Indexer.Methods
            {
                Get = "value",
            });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentResultsThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}