namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;
using MooVC.Syntax.CSharp.Operators.ConversionTests;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenOperatorsIsUndefined()
    {
        // Act
        var subject = new Operators();

        // Assert
        subject.Binaries.ShouldBeEmpty();
        subject.Comparisons.ShouldBeEmpty();
        subject.Conversions.ShouldBeEmpty();
        subject.Unaries.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];

        // Act
        var subject = new Operators
        {
            Binaries = binaries,
            Comparisons = comparisons,
            Conversions = conversions,
            Unaries = unaries,
        };

        // Assert
        subject.Binaries.ShouldBe(binaries);
        subject.Comparisons.ShouldBe(comparisons);
        subject.Conversions.ShouldBe(conversions);
        subject.Unaries.ShouldBe(unaries);
        subject.IsUndefined.ShouldBeFalse();
    }
}