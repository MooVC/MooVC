namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Binaries).IsEqualTo(expectedBinaries);
        _ = await Assert.That(result.Comparisons).IsEqualTo(original.Comparisons);
        _ = await Assert.That(result.Conversions).IsEqualTo(original.Conversions);
        _ = await Assert.That(result.Unaries).IsEqualTo(original.Unaries);
        _ = await Assert.That(original.Binaries).IsEqualTo(originalBinaries);
    }
}