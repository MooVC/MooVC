namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenWithBinariesIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedBinaries()
    {
        // Arrange
        ImmutableArray<Binary> originalBinaries = [BinaryTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(binaries: originalBinaries);
        ImmutableArray<Binary> updatedBinaries = [BinaryTestsData.Create(@operator: Binary.Type.Multiply)];

        // Act
        Operators result = original.WithBinaries(updatedBinaries);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Binaries.ShouldBe(updatedBinaries);
        result.Comparisons.ShouldBe(original.Comparisons);
        result.Conversions.ShouldBe(original.Conversions);
        result.Unaries.ShouldBe(original.Unaries);
        original.Binaries.ShouldBe(originalBinaries);
    }
}
