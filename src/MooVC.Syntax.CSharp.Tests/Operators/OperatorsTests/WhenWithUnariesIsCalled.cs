namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenWithUnariesIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedUnaries()
    {
        // Arrange
        ImmutableArray<Unary> originalUnaries = [UnaryTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(unaries: originalUnaries);
        Unary[] updatedUnaries = [UnaryTestsData.Create(@operator: Unary.Type.Minus)];
        IEnumerable<Unary> expectedUnaries = originalUnaries.Union(updatedUnaries);

        // Act
        Operators result = original.WithUnaries(updatedUnaries);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Binaries.ShouldBe(original.Binaries);
        result.Comparisons.ShouldBe(original.Comparisons);
        result.Conversions.ShouldBe(original.Conversions);
        result.Unaries.ShouldBe(expectedUnaries);
        original.Unaries.ShouldBe(originalUnaries);
    }
}