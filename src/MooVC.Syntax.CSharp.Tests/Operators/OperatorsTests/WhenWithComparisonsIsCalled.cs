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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Binaries).IsEqualTo(original.Binaries);
        await Assert.That(result.Comparisons).IsEqualTo(expectedComparisons);
        await Assert.That(result.Conversions).IsEqualTo(original.Conversions);
        await Assert.That(result.Unaries).IsEqualTo(original.Unaries);
        await Assert.That(original.Comparisons).IsEqualTo(originalComparisons);
    }
}