namespace MooVC.Syntax.CSharp.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenWithBinariesIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedBinaries()
    {
        // Arrange
        ImmutableArray<Binary> originalBinaries = [BinaryTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(binaries: originalBinaries);
        Binary[] updatedBinaries = [BinaryTestsData.Create(@operator: Binary.Type.Multiply)];
        IEnumerable<Binary> expectedBinaries = originalBinaries.Union(updatedBinaries);

        // Act
        Operators result = original.WithBinaries(updatedBinaries);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Binaries).IsEquivalentTo([.. expectedBinaries]);
        _ = await Assert.That(result.Comparisons).IsEquivalentTo(original.Comparisons);
        _ = await Assert.That(result.Conversions).IsEquivalentTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEquivalentTo(original.Unaries);
        _ = await Assert.That(original.Binaries).IsEquivalentTo(originalBinaries);
    }
}