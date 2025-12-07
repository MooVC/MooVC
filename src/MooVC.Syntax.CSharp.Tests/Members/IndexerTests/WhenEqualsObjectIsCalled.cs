namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object comparison = subject;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualIndexerThenReturnsTrue()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object comparison = IndexerTestsData.Create();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenIndexerWithDifferentParameterThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object comparison = IndexerTestsData.Create(
            parameter: ParameterTestsData.Create(modifier: Parameter.Mode.Out));

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenIndexerWithDifferentResultThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        object comparison = IndexerTestsData.Create(result: new Result { Type = typeof(Guid) });

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenIndexerWithDifferentScopeThenReturnsFalse()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create(scope: Scope.Private);
        object comparison = IndexerTestsData.Create(scope: Scope.Public);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }
}
