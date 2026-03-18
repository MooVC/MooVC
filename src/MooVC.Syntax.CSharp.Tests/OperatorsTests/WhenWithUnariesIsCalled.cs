namespace MooVC.Syntax.CSharp.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.UnaryTests;

public sealed class WhenWithUnariesIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedUnaries()
    {
        // Arrange
        ImmutableArray<Unary> originalUnaries = [UnaryTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(unaries: originalUnaries);
        Unary[] updatedUnaries = [UnaryTestsData.Create(@operator: Unary.Type.Minus)];
        IEnumerable<Unary> expectedUnaries = originalUnaries.Union(updatedUnaries);

        // Act
        Operators result = original.WithUnaries(updatedUnaries);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Binaries).IsEquivalentTo(original.Binaries);
        _ = await Assert.That(result.Comparisons).IsEquivalentTo(original.Comparisons);
        _ = await Assert.That(result.Conversions).IsEquivalentTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEquivalentTo([.. expectedUnaries]);
        _ = await Assert.That(original.Unaries).IsEquivalentTo(originalUnaries);
    }
}