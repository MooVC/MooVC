namespace MooVC.Syntax.CSharp.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.ComparisonTests;

public sealed class WhenWithComparisonsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedComparisons()
    {
        // Arrange
        ImmutableArray<Comparison> originalComparisons = [ComparisonTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(comparisons: originalComparisons);
        Comparison[] updatedComparisons = [ComparisonTestsData.Create(@operator: Comparison.Type.Inequality)];
        IEnumerable<Comparison> expectedComparisons = originalComparisons.Union(updatedComparisons);

        // Act
        Operators result = original.WithComparisons(updatedComparisons);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Binaries).IsEquivalentTo(original.Binaries);
        _ = await Assert.That(result.Comparisons).IsEquivalentTo([.. expectedComparisons]);
        _ = await Assert.That(result.Conversions).IsEquivalentTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEquivalentTo(original.Unaries);
        _ = await Assert.That(original.Comparisons).IsEquivalentTo(originalComparisons);
    }
}