namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorConversionConversionIsCalled
{
    [Test]
    public async Task GivenEquivalentConversionsThenReturnsTrue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentConversionsThenReturnsFalse()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create(subject: new Symbol { Name = "SomethingElse" });

        // Act
        bool result = first == second;

        // Assert
        await Assert.That(result).IsFalse();
    }
}