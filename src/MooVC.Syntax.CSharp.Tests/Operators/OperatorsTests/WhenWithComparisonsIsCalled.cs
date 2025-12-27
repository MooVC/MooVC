namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenWithComparisonsIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedComparisons()
    {
        // Arrange
        ImmutableArray<Comparison> originalComparisons = [ComparisonTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(comparisons: originalComparisons);
        Comparison[] updatedComparisons = [ComparisonTestsData.Create(@operator: Comparison.Type.Inequality)];
        IEnumerable<Comparison> expectedComparisons = originalComparisons.Union(updatedComparisons);

        // Act
        Operators result = original.WithComparisons(updatedComparisons);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Binaries.ShouldBe(original.Binaries);
        result.Comparisons.ShouldBe(expectedComparisons);
        result.Conversions.ShouldBe(original.Conversions);
        result.Unaries.ShouldBe(original.Unaries);
        original.Comparisons.ShouldBe(originalComparisons);
    }
}