namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenCodesMatch()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create();

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldBe(secondCode);
    }

    [Fact]
    public void GivenDifferentParametersThenCodesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create(
            parameter: ParameterTestsData.Create(modifier: Parameter.Mode.Out));

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }

    [Fact]
    public void GivenDifferentResultsThenCodesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create();
        Indexer second = IndexerTestsData.Create(result: new Result { Type = typeof(Guid) });

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }

    [Fact]
    public void GivenDifferentScopesThenCodesDiffer()
    {
        // Arrange
        Indexer first = IndexerTestsData.Create(scope: Scope.Internal);
        Indexer second = IndexerTestsData.Create(scope: Scope.Public);

        // Act
        int firstCode = first.GetHashCode();
        int secondCode = second.GetHashCode();

        // Assert
        firstCode.ShouldNotBe(secondCode);
    }
}
