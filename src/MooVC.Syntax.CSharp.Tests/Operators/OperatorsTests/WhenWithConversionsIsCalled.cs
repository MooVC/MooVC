namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithConversionsIsCalled
{
    private const string Subject = "Alternate";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedConversions()
    {
        // Arrange
        ImmutableArray<Conversion> originalConversions = [ConversionTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(conversions: originalConversions);
        Conversion[] updatedConversions = [ConversionTestsData.Create(subject: new Symbol { Name = Subject })];
        IEnumerable<Conversion> expectedConversions = originalConversions.Union(updatedConversions);

        // Act
        Operators result = original.WithConversions(updatedConversions);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Binaries).IsEquivalentTo(original.Binaries);
        _ = await Assert.That(result.Comparisons).IsEquivalentTo(original.Comparisons);
        _ = await Assert.That(result.Conversions).IsEquivalentTo([.. expectedConversions]);
        _ = await Assert.That(result.Unaries).IsEquivalentTo(original.Unaries);
        _ = await Assert.That(original.Conversions).IsEquivalentTo(originalConversions);
    }
}