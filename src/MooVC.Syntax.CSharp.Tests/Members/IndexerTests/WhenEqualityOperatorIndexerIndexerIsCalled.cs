namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorIndexerIndexerIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Indexer? left = default;
        Indexer? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Indexer? left = default;
        Indexer right = IndexerTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create();

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create(parameter: new Parameter { Name = "alternate" });

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentBehavioursThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();

        Indexer right = IndexerTestsData.Create(
            behaviours: new Indexer.Methods
            {
                Get = Snippet.From("value"),
            });

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentResultsThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create(
            result: new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = "int" },
            });

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}