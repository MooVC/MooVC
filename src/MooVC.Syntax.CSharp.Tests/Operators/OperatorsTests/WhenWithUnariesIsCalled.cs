namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

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
        ImmutableArray<Unary> updatedUnaries = [UnaryTestsData.Create(@operator: Unary.Type.Minus)];

        // Act
        Operators result = original.WithUnaries(updatedUnaries);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Binaries.ShouldBe(original.Binaries);
        result.Comparisons.ShouldBe(original.Comparisons);
        result.Conversions.ShouldBe(original.Conversions);
        result.Unaries.ShouldBe(updatedUnaries);
        original.Unaries.ShouldBe(originalUnaries);
    }
}
