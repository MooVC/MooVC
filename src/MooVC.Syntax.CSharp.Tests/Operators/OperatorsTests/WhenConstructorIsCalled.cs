namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;
using MooVC.Syntax.CSharp.Operators.ConversionTests;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenOperatorsIsUndefined()
    {
        // Act
        var subject = new Operators();

        // Assert
        await Assert.That(subject.Binaries).IsEmpty();
        await Assert.That(subject.Comparisons).IsEmpty();
        await Assert.That(subject.Conversions).IsEmpty();
        await Assert.That(subject.Unaries).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        await Assert.That(subject.Binaries).IsEqualTo(binaries);
        await Assert.That(subject.Comparisons).IsEqualTo(comparisons);
        await Assert.That(subject.Conversions).IsEqualTo(conversions);
        await Assert.That(subject.Unaries).IsEqualTo(unaries);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}