namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Binaries).IsEqualTo(original.Binaries);
        _ = await Assert.That(result.Comparisons).IsEqualTo(expectedComparisons);
        _ = await Assert.That(result.Conversions).IsEqualTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEqualTo(original.Unaries);
        _ = await Assert.That(original.Comparisons).IsEqualTo(originalComparisons);
    }
}