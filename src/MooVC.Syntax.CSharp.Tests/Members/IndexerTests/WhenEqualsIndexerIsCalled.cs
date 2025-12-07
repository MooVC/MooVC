namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Members.ParameterTests;

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
    public void GivenEqualValuesThenReturnsTrue()
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
    public void GivenDifferentParametersThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Indexer target = IndexerTestsData.Create(
            parameter: ParameterTestsData.Create(modifier: Parameter.Mode.Out));

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
        Indexer target = IndexerTestsData.Create(result: new Result { Type = typeof(Guid) });

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(scope: Scope.Internal);
        Indexer target = IndexerTestsData.Create(scope: Scope.Private);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}
