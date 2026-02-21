namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithConversionsIsCalled
{
    private const string Subject = "Alternate";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedConversions()
    {
        // Arrange
        ImmutableArray<Conversion> originalConversions = [ConversionTestsData.Create()];
        Operators original = OperatorsSubjectData.Create(conversions: originalConversions);
        Conversion[] updatedConversions = [ConversionTestsData.Create(subject: new Symbol { Name = Subject })];
        IEnumerable<Conversion> expectedConversions = originalConversions.Union(updatedConversions);

        // Act
        Operators result = original.WithConversions(updatedConversions);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Binaries.ShouldBe(original.Binaries);
        result.Comparisons.ShouldBe(original.Comparisons);
        result.Conversions.ShouldBe(expectedConversions);
        result.Unaries.ShouldBe(original.Unaries);
        original.Conversions.ShouldBe(originalConversions);
    }
}