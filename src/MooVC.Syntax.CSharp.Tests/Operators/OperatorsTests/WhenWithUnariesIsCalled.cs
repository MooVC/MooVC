namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Binaries).IsEqualTo(original.Binaries);
        await Assert.That(result.Comparisons).IsEqualTo(original.Comparisons);
        await Assert.That(result.Conversions).IsEqualTo(original.Conversions);
        await Assert.That(result.Unaries).IsEqualTo(expectedUnaries);
        await Assert.That(original.Unaries).IsEqualTo(originalUnaries);
    }
}