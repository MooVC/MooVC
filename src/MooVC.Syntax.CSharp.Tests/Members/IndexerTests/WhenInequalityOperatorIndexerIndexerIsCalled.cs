namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenInequalityOperatorIndexerIndexerIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Indexer? left = default;
        Indexer? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Indexer? left = default;
        Indexer right = IndexerTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create(parameter: new Parameter { Name = "alternate" });

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentBehavioursThenReturnsTrue()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();

        Indexer right = IndexerTestsData.Create(
            behaviours: new Indexer.Methods
            {
                Get = Snippet.From("value"),
            });

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentResultsThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsTrue()
    {
        // Arrange
        Indexer left = IndexerTestsData.Create();
        Indexer right = IndexerTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
