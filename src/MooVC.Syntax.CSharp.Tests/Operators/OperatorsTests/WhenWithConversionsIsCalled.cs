namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Binaries).IsEqualTo(original.Binaries);
        await Assert.That(result.Comparisons).IsEqualTo(original.Comparisons);
        await Assert.That(result.Conversions).IsEqualTo(expectedConversions);
        await Assert.That(result.Unaries).IsEqualTo(original.Unaries);
        await Assert.That(original.Conversions).IsEqualTo(originalConversions);
    }
}