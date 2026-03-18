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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Binaries).IsEqualTo(original.Binaries);
        _ = await Assert.That(result.Comparisons).IsEqualTo(original.Comparisons);
        _ = await Assert.That(result.Conversions).IsEqualTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEqualTo(expectedUnaries);
        _ = await Assert.That(original.Unaries).IsEqualTo(originalUnaries);
    }
}